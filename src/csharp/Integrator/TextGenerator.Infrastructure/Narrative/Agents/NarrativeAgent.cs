using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TextGenerator.Core.Interfaces.EdgeAI;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Interfaces.RAG;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Infrastructure.Narrative.Agents;

/// <summary>
/// Основной генератор диалогов и квестов, использующий LLM, RAG, кэш и контекст мира.
/// </summary>
public class NarrativeAgent : INarrativeAgent
{
    private readonly ILLMClient _llm;
    private readonly IPreprocessor _preprocessor;
    private readonly IPostprocessor _postprocessor;
    private readonly IRAGService _rag; 
    private readonly IMemoryCache _cache;
    private readonly INarrativeEnvironment _narrativeEnv;
    private readonly ILogger<NarrativeAgent> _logger;
        
    // Храним последний узел диалога для каждой пары (NPC, Player)
    private readonly ConcurrentDictionary<(int npcId, int playerId), DialogueNode> _lastNode = new();

    public NarrativeAgent(ILLMClient llm, IPreprocessor preprocessor, IPostprocessor postprocessor,
        IRAGService rag, IMemoryCache cache, INarrativeEnvironment narrativeEnv,
        ILogger<NarrativeAgent> logger)
    {
        _llm = llm;
        _preprocessor = preprocessor;
        _postprocessor = postprocessor;
        _rag = rag;
        _cache = cache;
        _narrativeEnv = narrativeEnv;
        _logger =  logger;
    }

    public async Task<DialogueNode> GenerateDialogue(SmartNPC npc, Player player, DialogueNode? parentNode, int? depth, int variety)
    {
        var systemPrompt = _preprocessor.BuildSystemPrompt(npc);
            
        // Определяем playerInput на основе выбранного узла
        string playerInput = parentNode?.PlayerText ?? string.Empty;
            
        // Формируем ключ кэша с учётом parentNode (если есть)
        var parentHash = parentNode?.Id.ToString() ?? "null";
        var cacheKey = $"dial_{npc.Id}_{player.Id}_{playerInput.GetHashCode()}_{depth}_{variety}_{parentHash}";
            
        if (_cache.TryGetValue(cacheKey, out DialogueNode? cached))
            return cached!;

        // 2. Получение релевантного контекста из NarrativeEnvironment
        var context = await _narrativeEnv.GetRelevantContext(npc, player, playerInput);
            
        DialogueNode result;

        if (depth is <= 1 or null)
        {
            // STEPPED MODE
            // Если нет последнего узла, создаём пустой корневой узел (начальную фразу NPC нужно получить отдельно)
            // В реальности LLM должна сгенерировать сначала корневую фразу, а затем варианты.
            // Упрощённо: создаём корневой узел с пустым NPCText, затем вызываем парсер.
            var currentNode = parentNode ?? new DialogueNode 
            { 
                Name = "0", 
                InterlocutorNPC = npc.Name, 
                Childs = new List<DialogueNode>() 
            };
                
            if (parentNode == null)
            {
                _logger.LogDebug("Creating intro phrase");
                // Вступительная фраза – возвращает string
                currentNode.NPCText = ExtractNpcPhrase(await ProcessWithPipeline(
                    playerInput,
                    systemPrompt,
                    variety,
                    () => _preprocessor.BuildIntroductoryPhrasePrompt(npc),
                    512,
                    raw => raw  // без постобработки, просто строка
                    ), npc.Name);
                _logger.LogDebug("Intro phrase: {phrase}", currentNode.NPCText);
            }
                
            _logger.LogDebug("Make step");
            // Stepped режим – постобработчик добавляет варианты в currentNode
            await ProcessWithPipeline(
                playerInput,
                systemPrompt,
                variety,
                () => _preprocessor.BuildSteppedDialoguePrompt(npc, currentNode, variety, context),
                1024,
                raw =>
                {
                    _postprocessor.ParseSteppedDialogueResponse(npc, currentNode, raw);
                    // Если модель сгенерировала больше вариантов, обрезаем до variety
                    if (currentNode.Childs != null && currentNode.Childs.Count > variety)
                    {
                        _logger.LogWarning("Model generated {Generated} options, expected {Variety}. Truncating.",
                            currentNode.Childs.Count, variety);
                        currentNode.Childs = currentNode.Childs.Take(variety).ToList();
                    }
                    return raw;
                }
            );
    
            result = currentNode;
        }
        else
        {
            // Branched режим
            result = await BuildBranchedDialogueUsingSteps(npc, player, depth.Value, variety);
        }

        // 7. Сохраняем в кэш
        _cache.Set(cacheKey, result, TimeSpan.FromMinutes(10));

        // 8. Сохраняем в память (RAG)
        await _rag.StoreInteraction($"(Player chose: {playerInput}) NPC:{npc.Name} said: {result.NPCText}", 
            $"depth={depth}_variety={variety}");
        return result;
    }
        
    /// <summary>
    /// Строит ветвистое дерево диалога заданной глубины,
    /// последовательно вызывая перегрузки GenerateDialogue для каждого узла.
    /// </summary>
    private async Task<DialogueNode> BuildBranchedDialogueUsingSteps(
        SmartNPC npc, Player player, int maxDepth, int variety)
    {
        _logger.LogInformation(
            "Building branched dialogue iteratively: maxDepth={MaxDepth}, variety={Variety}", maxDepth, variety);

        // 1. Получаем корневой узел с вступительной фразой и первыми дочерними вариантами (глубина 1)
        //    Используем перегрузку без parentNode и depth.
        DialogueNode root = await GenerateDialogue(npc, player, variety);

        // Если корень уже имеет дочерние узлы, но глубина равна 1 – возвращаем как есть
        if (maxDepth == 1)
            return root;

        // 2. Обход в ширину (BFS) по узлам, пока не достигнем maxDepth
        var queue = new Queue<(DialogueNode node, int currentDepth)>();
        foreach (var child in root.Childs ?? Enumerable.Empty<DialogueNode>())
            queue.Enqueue((child, 1));

        while (queue.Count > 0)
        {
            var (node, depth) = queue.Dequeue();
            if (depth >= maxDepth)
                continue;

            _logger.LogDebug("Generating children for node '{NodeName}' at depth {Depth}", node.Name, depth);

            // 3. Для каждого узла вызываем stepped-генерацию (перегрузка с parentNode)
            //    Она сама добавит дочерние узлы в node.Childs.
            await GenerateDialogue(npc, player, node, variety);

            // 4. Добавляем новые дочерние узлы в очередь для дальнейшего раскрытия
            if (node.Childs == null) continue;
            foreach (var child in node.Childs)
                queue.Enqueue((child, depth + 1));
        }

        return root;
    }
        
    public async Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription)
    {
        var prompt = _preprocessor.BuildQuestPrompt(npc, player, goalDescription); // новый метод в LLMPromptBuilder
        var rawQuest = await _llm.GenerateWithSystemAsync(
            prompt, _preprocessor.BuildSystemPrompt(npc), null, maxTokens: 1024);
        _logger.LogDebug("Raw quest response: {Response}", rawQuest);
        var quest = _postprocessor.ParseQuestResponse(rawQuest);
        await _rag.StoreInteraction($"Сгенерирован квест: {quest.Name}", $"NPC={npc.Name}");
        return quest;
    }
        
    public Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        int variety)
        => GenerateDialogue(npc, player, null, null, variety);
        
    public Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        DialogueNode parentNode,
        int variety)
        => GenerateDialogue(npc, player, parentNode, null, variety);
        
    public Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        int? depth,
        int variety)
        => GenerateDialogue(npc, player, null, depth, variety);
        
    private async Task<T> ProcessWithPipeline<T>(
        string playerInput,
        string systemPrompt,
        int variety,
        Func<string> buildPrompt,           // фабрика промпта (синхронная, но может быть async)
        int maxTokens,
        Func<string, T> postprocess         // постобработка ответа LLM
    )
    {
        _logger.LogInformation("ProcessWithPipeline started. PlayerInput: {PlayerInput}, MaxTokens: {MaxTokens}", 
            playerInput?.Length > 50 ? playerInput[..50] + "..." : playerInput, maxTokens);
            
        // 3. Формирование промпта для следующего шага
        var prompt = buildPrompt();
        _logger.LogDebug("Generated prompt length: {PromptLength} characters", prompt.Length);
            
        _logger.LogDebug("Generated prompt length: {PromptLength} characters", prompt.Length);
            
        // 4. RAG-усиление
        var stopwatch = Stopwatch.StartNew();
        var augmented = await _rag.AugmentPrompt(playerInput, prompt);
        stopwatch.Stop();
        _logger.LogInformation("RAG augmentation completed in {ElapsedMs} ms. Augmented prompt length: {Length}", 
            stopwatch.ElapsedMilliseconds, augmented.Length);
            
        // 5. Генерация через локальную LLM
        stopwatch.Restart();
        stopwatch.Restart();
        string rawResponse;
        try
        {
            rawResponse = await _llm.GenerateWithSystemAsync(augmented, systemPrompt, variety, maxTokens);
            stopwatch.Stop();
            _logger.LogInformation("LLM generation completed in {ElapsedMs} ms. Response length: {ResponseLength}", 
                stopwatch.ElapsedMilliseconds, rawResponse.Length);
            _logger.LogTrace("LLM raw response: {RawResponse}", 
                rawResponse.Length > 200 ? rawResponse[..200] + "..." : rawResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "LLM generation failed after {ElapsedMs} ms", stopwatch.ElapsedMilliseconds);
            throw;
        }
            
        _logger.LogDebug("Augmented prompt: {Prompt}", augmented);
        _logger.LogDebug("Raw LLM response: {Response}", rawResponse);
    
        // Постобработка
        T result;
        try
        {
            result = postprocess(rawResponse);
            _logger.LogInformation("Postprocessing completed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Postprocessing failed for response: {RawResponse}", 
                rawResponse.Length > 200 ? rawResponse[..200] + "..." : rawResponse);
            throw;
        }
        return result;
    }

    // Альтернатива: если buildPrompt асинхронный
    private async Task<T> ProcessWithPipelineAsync<T>(
        string playerInput,
        Func<Task<string>> buildPromptAsync,
        int maxTokens,
        Func<string, T> postprocess
    )
    {
        // 3. Формирование промпта для следующего шага
        var prompt = await buildPromptAsync();
            
        // 4. RAG-усиление
        var augmented = await _rag.AugmentPrompt(playerInput, prompt);
            
        // 5. Генерация через локальную LLM
        var rawResponse = await _llm.GenerateAsync(augmented, maxTokens);
            
        // 6. Постобработка – получаем диалог
        return postprocess(rawResponse);
    }
        
    private string ExtractNpcPhrase(string rawResponse, string npcName)
    {
        if (string.IsNullOrWhiteSpace(rawResponse))
            return string.Empty;

        // Получаем сокращённое имя (первое слово)
        string shortName = npcName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
    
        // Функция для попытки извлечения фразы по заданному имени и паттерну
        string TryExtract(string name, bool requireQuotes)
        {
            if (string.IsNullOrEmpty(name))
                return null;
        
            string pattern;
            if (requireQuotes)
                pattern = $@"{Regex.Escape(name)}:\s*""(?<phrase>[^""]+)""";
            else
                pattern = $@"{Regex.Escape(name)}:\s*(?<phrase>[^""]+)";
        
            var match = Regex.Match(rawResponse, pattern);
            return match.Success ? match.Groups["phrase"].Value : null;
        }

        // 1. Точное полное имя, текст в кавычках
        string result = TryExtract(npcName, true);
        if (result != null) return result;

        // 2. Точное полное имя, текст без кавычек
        result = TryExtract(npcName, false);
        if (result != null) return result;

        // 3. Сокращённое имя (первое слово), текст в кавычках
        result = TryExtract(shortName, true);
        if (result != null) return result;

        // 4. Сокращённое имя, текст без кавычек
        result = TryExtract(shortName, false);
        if (result != null) return result;

        // 5. Просто текст в двойных кавычках (без указания имени)
        var match = Regex.Match(rawResponse, @"""(?<phrase>[^""]+)""");
        if (match.Success)
            return match.Groups["phrase"].Value;

        // 6. Обрезаем "User:" в конце, если ничего не нашли
        var trimmed = rawResponse.Trim();
        if (trimmed.EndsWith("User:", StringComparison.OrdinalIgnoreCase))
            trimmed = trimmed.Substring(0, trimmed.Length - 5).Trim();

        return trimmed;
    }
}