using MainPlugin.Core.Entities.Models.Interactions;
using MainPlugin.Core.Entities.Models.Interactors;
using MainPlugin.Infrastructure.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Infrastructure.Helpers
{
    public static class DialogueHelper
    {
        public static string GenerateBasicBranchedDialogueRequest(this SmartNPC npc, int depth, int variety)
            => new Preprocessor().GenerateBasicBranchedDialogueRequest(npc, depth, variety);

        public static DialogueEntry DecodeAPIBranchedDialogueResponse(this SmartNPC npc, string response)
            => new Postprocessor().DecodeAPIBranchedDialogueResponse(npc, response);
    }
}
