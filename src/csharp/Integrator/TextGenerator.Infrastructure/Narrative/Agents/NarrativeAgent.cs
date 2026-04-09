using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
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
        //private readonly IRewardCalculator _reward;
        private readonly ITextSummarizer _textSummarizer;
        private readonly IMemoryCache _cache;
        private readonly INarrativeEnvironment _narrativeEnv;
        
        // Храним последний узел диалога для каждой пары (NPC, Player)
        private readonly ConcurrentDictionary<(int npcId, int playerId), DialogueNode> _lastNode = new();

        public NarrativeAgent(ILLMClient llm, IPreprocessor preprocessor, IPostprocessor postprocessor,
            IRAGService rag, IRewardCalculator reward, ITextSummarizer textSummarizer, IMemoryCache cache, INarrativeEnvironment narrativeEnv)
        {
            _llm = llm;
            _preprocessor = preprocessor;
            _postprocessor = postprocessor;
            _rag = rag;
            //_reward = reward;
            _textSummarizer = textSummarizer;
            _cache = cache;
            _narrativeEnv = narrativeEnv;
        }

        public async Task<DialogueEntry> GenerateDialogue(SmartNPC npc, Player player, string playerInput, int depth, int variety)
        {
            var key = (npc.Id, player.Id);
            _lastNode.TryGetValue(key, out var lastNode);
            
            // 1. Проверка кэша
            string cacheKey = $"{npc.Id}_{player.Id}_{playerInput.GetHashCode()}";
            if (_cache.TryGetValue(cacheKey, out DialogueEntry cached))
                return cached;

            // 2. Получение релевантного контекста из NarrativeEnvironment
            var context = await _narrativeEnv.GetRelevantContext(npc, player, playerInput);

            // 3. Формирование промпта для следующего шага (stepped)
            string prompt = _preprocessor.BuildSteppedDialoguePrompt(npc, lastNode, variety, context);

            // 4. RAG-усиление
            var augmentedPrompt = await _rag.AugmentPrompt(playerInput, prompt);

            // 5. Генерация через локальную LLM
            string rawResponse = await _llm.GenerateAsync(augmentedPrompt, maxTokens: 256);

            // 6. Постобработка – получаем только следующий узел диалога
            var nextNode = _postprocessor.ParseSteppedDialogueResponse(npc, rawResponse);
            var entry = new DialogueEntry { Text = nextNode.NPCText, Childs = new List<DialogueNode> { nextNode } };

            // 7. Сохраняем в кэш
            _cache.Set(cacheKey, entry, TimeSpan.FromMinutes(10));

            // 8. Сохраняем в память (RAG)
            await _rag.StoreInteraction($"NPC:{npc.Name} said: {nextNode.NPCText}", $"playerInput={playerInput}");
    
            _lastNode[key] = nextNode; // для следующего шага
            return entry;
        }

        public async Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription)
        {
            var prompt = _preprocessor.BuildQuestPrompt(npc, player, goalDescription); // новый метод в LLMPromptBuilder
            var rawQuest = await _llm.GenerateAsync(prompt);
            var quest = _postprocessor.ParseQuestResponse(rawQuest);
            await _rag.StoreInteraction($"Сгенерирован квест: {quest.Name}", $"NPC={npc.Name}");
            return quest;
        }
    }