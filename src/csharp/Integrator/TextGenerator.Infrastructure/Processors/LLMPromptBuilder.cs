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
    //private readonly IRAGService _rag;
    private readonly ITextSummarizer _summarizer;
    private readonly PromptOptions _options;

    public LLMPromptBuilder(
        INarrativeEnvironment narrativeEnv,
        //IRAGService rag,
        ITextSummarizer summarizer,
        IOptions<PromptOptions> options)
    {
        _narrativeEnv = narrativeEnv;
        //_rag = rag;
        _summarizer = summarizer;
        _options = options.Value;
    }
        
    public Task<string> BuildBranchedDialoguePromptAsync(SmartNPC npc, int? depth, int variety)
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
        return Task.FromResult(prompt);
    }

    public Task<string> BuildSteppedDialoguePromptAsync(SmartNPC npc, DialogueNode? previousNode, int variety, WorldContext context)
    {
        var prevStep = previousNode != null 
            ? !string.IsNullOrEmpty(previousNode.PlayerText) 
                ? $"Previous: Player said \"{previousNode.PlayerText}\" → {npc.Name} replied \"{previousNode.NPCText}\"" 
                : $"{npc.Name}: \"{previousNode.NPCText}\""
            : "This is the start of conversation.";
    
        var contextInfo = JsonConvert.SerializeObject(context, Formatting.Indented);
    
        var prompt = $"""
                      World context: {contextInfo}
                      {prevStep}

                      Provide {variety} different ways the player could respond, each followed by {npc.Name}'s reply.

                      Format exactly like this example (use double quotes around each phrase):

                      1. Player: "Phrase"
                         {npc.Name}: "Phrase"

                      2. Player: "Phrase"
                         {npc.Name}: "Phrase"

                      (Continue numbering up to {variety}. Replace phrase with your text.)

                      IMPORTANT: Do not include any introductory or concluding text. Start directly with "1.".
                      """;
    
        return Task.FromResult(prompt);
    }

    public async Task<string> BuildQuestPromptAsync(SmartNPC npc, Player player, string goalDescription)
    {
        var context = await _narrativeEnv.GetRelevantContext(npc, player, goalDescription);
    
        var exampleQuest = new
        {
            name = "The Missing Artifact",
            description = "Retrieve the ancient artifact from the goblin camp.",
            difficulty = 2,
            requirements = new[] 
            { 
                new { type = "collect", target = "Ancient Artifact", count = 1 },
                new { type = "kill", target = "Goblin", count = 5 }
            },
            rewards = new[] 
            { 
                new { type = "exp", amount = 150 },
                new { type = "gold", amount = 50 }
            }
        };

        string exampleJson = JsonConvert.SerializeObject(exampleQuest, Formatting.Indented);

        var prompt = $"""
                      You are a NPC that generate quest for a fantasy RPG game.

                      Player: {player.Name}, Level {player.Level}
                      Goal: {goalDescription}
                      World context: {JsonConvert.SerializeObject(context)}

                      Generate a quest as a JSON object. Follow exactly this format:
                      {exampleJson}

                      Output ONLY the JSON object. Do not include any other text.
                      """;

        return prompt;
    }

    public async Task<string> BuildIntroductoryPhrasePromptAsync(SmartNPC npc)
    {
        return "Generate a single opening line to start a conversation. No more than 2 sentences.";
    }

    // Вспомогательные методы
    private string BuildNPCProfile(SmartNPC npc)
    {
        return $"""Name: {npc.Name}. Type: {npc.Type}. Age: {npc.Age}. Appearance: {npc.Appearance}. Profession: {npc.Profession}. Personal characteristics: {string.Join(", ", npc.PersonalCharacteristics)}. Behavior: {string.Join(", ", npc.Behaviors)}.""";
    }
    
    public string BuildSystemPrompt(SmartNPC npc)
    {
        // Используем существующий метод BuildNPCProfile из LLMPromptBuilder
        // Для этого нужно либо внедрить ILLMPromptBuilder, либо вынести формирование профиля в отдельный статический класс.
        // Простейший вариант – скопировать логику сюда (но лучше через DI).
        var profile = BuildNPCProfile(npc);
    
        return $"You are an NPC in an RPG game. Your personality is {profile} Stay in character, speak naturally, and never generate text for the Player. Keep responses concise (one sentence).";
    }

    private string BuildBranchConstraints(int? depth, int variety)
    {
        if (depth == null) return "";
        var sb = new StringBuilder();
        sb.AppendLine($"Generate a dialogue tree of depth {depth} with {variety} branches at each level.");
        sb.AppendLine($"Total leaf nodes: {Math.Pow(variety, (double)depth!)}.");
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
