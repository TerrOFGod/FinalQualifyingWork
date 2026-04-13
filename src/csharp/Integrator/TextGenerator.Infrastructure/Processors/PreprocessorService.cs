using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Infrastructure.Processors;

public class PreprocessorService : IPreprocessor
{
    private readonly ILLMPromptBuilder _promptBuilder;

    public PreprocessorService(ILLMPromptBuilder promptBuilder)
    {
        _promptBuilder = promptBuilder;
    }

    public string BuildBranchedDialoguePrompt(SmartNPC npc, int? depth, int variety)
        => _promptBuilder.BuildBranchedDialoguePromptAsync(npc, depth, variety).GetAwaiter().GetResult();

    public string BuildSteppedDialoguePrompt(SmartNPC npc, DialogueNode? prevNode, int variety, WorldContext context)
        => _promptBuilder.BuildSteppedDialoguePromptAsync(npc, prevNode, variety, context).GetAwaiter().GetResult();

    public string BuildQuestPrompt(SmartNPC npc, Player player, string goalDescription)
        => _promptBuilder.BuildQuestPromptAsync(npc, player, goalDescription).GetAwaiter().GetResult();

    public string BuildIntroductoryPhrasePrompt(SmartNPC npc)
        => _promptBuilder.BuildIntroductoryPhrasePromptAsync(npc).GetAwaiter().GetResult();
    
    // Старые методы помечены Obsolete (опционально)
    [Obsolete("Use BuildBranchedDialoguePrompt instead")]
    public string GenerateBasicBranchedDialogueRequest(SmartNPC npc, int depth, int variety)
        => BuildBranchedDialoguePrompt(npc, depth, variety);
    
    [Obsolete("Use BuildSteppedDialoguePrompt instead")]
    public string GenerateBasicSteppedDialogueRequest(SmartNPC npc, DialogueNode prevNode, int variety, WorldContext context)
        => BuildSteppedDialoguePrompt(npc, prevNode, variety, context);
    
    [Obsolete("Use BuildQuestPrompt instead")]
    public string GenerateQuestPrompt(SmartNPC npc, Player player, string goalDescription)
        => BuildQuestPrompt(npc, player, goalDescription);
}