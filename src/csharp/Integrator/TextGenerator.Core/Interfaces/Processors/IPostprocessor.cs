using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Core.Interfaces.Processors
{
    public interface IPostprocessor
    {
        DialogueEntry DecodeAPIBranchedDialogueResponse(SmartNPC npc, string response);
        DialogueNode DecodeSingleStepDialogueResponse(SmartNPC npc, string response);

        Quest ParseQuest(string response);
        //Quest ParseQuest();
        //bool CheckСorrectness(); // планирую написать нейронку с подкреплением на python подключу с IronPython
    }
}
