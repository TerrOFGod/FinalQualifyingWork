using GPTTextGenerator.Entities.Models.Interactors;

namespace GPTTextGenerator.Entities.Interfaces.Processors
{
    public interface IPreprocessor
    {
        string GenerateBasicBranchedDialogueRequest(SmartNPC npc, int depth, int variety);
    }
}
