using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Interfaces.Processors
{
    public interface IPreprocessor
    {
        string GenerateBasicBranchedDialogueRequest(SmartNPC npc, int depth, int variety);
        string GenerateQuestPrompt(SmartNPC npc, Player player, string goalDescription);
        string GenerateBasicSteppedDialogueRequest(SmartNPC npc, DialogueNode prevNode, int variety, WorldContext context);
    }
}
