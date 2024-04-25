using MainPlugin.Core.Entities.Models.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Interfaces.Processors
{
    public interface IPreprocessor
    {
        string GenerateBasicBranchedDialogueRequest(SmartNPC npc, int depth, int variety);
    }
}
