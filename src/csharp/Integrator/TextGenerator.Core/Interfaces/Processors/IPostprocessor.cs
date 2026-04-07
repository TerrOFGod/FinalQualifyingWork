using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Processors
{
    public interface IPostprocessor
    {
        DialogueEntry DecodeAPIBranchedDialogueResponse(SmartNPC npc, string response);

        Quest ParseQuest(string response);
        //Quest ParseQuest();
        //bool CheckСorrectness(); // планирую написать нейронку с подкреплением на python подключу с IronPython
    }
}
