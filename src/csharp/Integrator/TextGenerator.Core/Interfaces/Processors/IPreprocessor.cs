using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Processors
{
    public interface IPreprocessor
    {
        string GenerateBasicBranchedDialogueRequest(SmartNPC npc, int depth, int variety);
        string GenerateQuestPrompt(SmartNPC npc, Player player, string goalDescription);
    }
}
