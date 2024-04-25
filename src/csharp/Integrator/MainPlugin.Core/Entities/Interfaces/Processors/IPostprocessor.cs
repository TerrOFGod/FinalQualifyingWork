using MainPlugin.Core.Entities.Models.Interactions;
using MainPlugin.Core.Entities.Models.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Interfaces.Processors
{
    public interface IPostprocessor
    {
        DialogueEntry DecodeAPIBranchedDialogueResponse(SmartNPC npc, string response);
        //Quest ParseQuest();
        //bool CheckСorrectness(); // планирую написать нейронку с подкреплением на python подключу с IronPython
    }
}
