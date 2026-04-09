using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Interfaces.RAG;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Infrastructure.Processors;

/// <summary>
/// Формирование промптов для языковой модели на основе данных NPC, игрока и контекста.
/// </summary>
public class LLMPromptBuilder : ILLMPromptBuilder
{
    private readonly INarrativeEnvironment _narrativeEnv;
    private readonly IRAGService _rag;
    private readonly ITextSummarizer _summarizer;
    private readonly PromptOptions _options;

    public LLMPromptBuilder(
        INarrativeEnvironment narrativeEnv,
        IRAGService rag,
        ITextSummarizer summarizer,
        IOptions<PromptOptions> options)
    {
        _narrativeEnv = narrativeEnv;
        _rag = rag;
        _summarizer = summarizer;
        _options = options.Value;
    }
        
    public async Task<string> BuildBranchedDialoguePromptAsync(SmartNPC npc, int depth, int variety)
    {
        var npcProfile = BuildNPCProfile(npc);
        var constraints = BuildBranchConstraints(depth, variety);
        var formatInstruction = 
            @"Format each line exactly as: 
              <variant> <PlayerName>: ""<player phrase>"" <NPCName>: ""<npc phrase>""
              Example: 1 Player: ""Hello"" Merchant: ""Welcome!""
              Use numbered variants like 1, 1.1, 1.2, 2, 2.1, etc.";
        
        var prompt = $"""
                      {npcProfile}
                      {constraints}
                      {formatInstruction}
                      Generate a complete branched dialogue tree. Start with level 0 (NPC's opening line).
                      """;
        
        // Улучшение: RAG-усиление базового промпта
        return await _rag.AugmentPrompt("branched dialogue generation", prompt);
    }

    public async Task<string> BuildSteppedDialoguePromptAsync(SmartNPC npc, DialogueNode? previousNode, int variety, WorldContext context)
    {
        var npcProfile = BuildNPCProfile(npc);
        var prevStep = previousNode != null 
            ? $"Previous: Player said \"{previousNode.PlayerText}\" → {npc.Name} replied \"{previousNode.NPCText}\""
            : "This is the start of conversation.";
        
        var contextInfo = JsonConvert.SerializeObject(context, Formatting.Indented);
        var options = string.Join("\n", Enumerable.Range(1, variety)
            .Select(i => $"{i}. Player: \"[Option {i}]\"\n   {npc.Name}: \"[Response to option {i}]\""));
        
        var prompt = $"""
                      {npcProfile}
                      World context: {contextInfo}
                      {prevStep}
                      Generate {variety} possible next steps. Each step must include a player phrase and NPC's response.
                      {options}
                      Keep each phrase under 2 sentences.
                      """;
        
        return await _rag.AugmentPrompt($"dialogue step for {npc.Name}", prompt);
    }

    public async Task<string> BuildQuestPromptAsync(SmartNPC npc, Player player, string goalDescription)
    {
        var context = await _narrativeEnv.GetRelevantContext(npc, player, goalDescription);
        var questTemplate = new
        {
            name = "Quest name",
            description = "Description",
            difficulty = 3,
            requirements = new[] { new { type = "kill", target = "goblin", count = 5 } },
            rewards = new[] { new { type = "exp", amount = 100 } }
        };
        
        var prompt = $"""
                      You are an RPG quest generator. 
                      NPC: {npc.Name} (profession: {npc.Profession}, traits: {string.Join(", ", npc.PersonalCharacteristics)})
                      Player: {player.Name}, level {player.Level}
                      Goal: {goalDescription}
                      World context: {JsonConvert.SerializeObject(context)}
                      Difficulty must be 1-5, rewards: exp, gold, items.
                      Output ONLY valid JSON in this format:
                      {JsonConvert.SerializeObject(questTemplate, Formatting.Indented)}
                      """;
        
        // Ограничиваем длину промпта
        if (EstimateTokenCount(prompt) > _options.MaxPromptTokens)
        {
            var summary = await _summarizer.Summarize(JsonConvert.SerializeObject(context));
            return $"{prompt}\n(Summarized context: {summary})";
        }
        return prompt;
    }

    public async Task<string> BuildIntroductoryPhrasePromptAsync(SmartNPC npc)
    {
        var npcProfile = BuildNPCProfile(npc);
        return $"{npcProfile}\nGenerate a single opening line from {npc.Name} to start a conversation. No more than 2 sentences.";
    }

    // Вспомогательные методы
    private string BuildNPCProfile(SmartNPC npc)
    {
        return $"""
                NPC: {npc.Name}
                Type: {npc.Type}
                Age: {npc.Age}
                Appearance: {npc.Appearance}
                Profession: {npc.Profession}
                Personality: {string.Join(", ", npc.PersonalCharacteristics)}
                Behavior: {string.Join(", ", npc.Behaviors)}
                """;
    }

    private string BuildBranchConstraints(int depth, int variety)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Generate a dialogue tree of depth {depth} with {variety} branches at each level.");
        sb.AppendLine($"Total leaf nodes: {Math.Pow(variety, depth)}.");
        sb.AppendLine("Level 0: NPC's opening line.");
        for (int i = 1; i <= depth; i++)
            sb.AppendLine($"Level {i}: For each previous player option, provide {variety} player responses and corresponding NPC replies.");
        return sb.ToString();
    }

    private int EstimateTokenCount(string text) => (int)(text.Length * 0.75);
}

public class PromptOptions
{
    public int MaxPromptTokens { get; set; } = 1800;
}
