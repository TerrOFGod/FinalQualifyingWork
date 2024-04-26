using GPTTextGenerator.Entities.Models.Interactions;
using GPTTextGenerator.Entities.Models.Interactors;

namespace GPTTextGenerator.Entities.Interfaces.Processors
{
    public interface IPostprocessor
    {
        DialogueEntry DecodeAPIBranchedDialogueResponse(SmartNPC npc, string response);
        //Quest ParseQuest();
        //bool CheckСorrectness(); // планирую написать нейронку с подкреплением на python подключу с IronPython
    }
}
