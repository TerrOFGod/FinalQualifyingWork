using GPTTextGenerator.Entities.Models.Interactions;
using GPTTextGenerator.Entities.Models.Interactors;
using Analyzer = GPTTextGenerator.Infrastructure.Analyzer.Analyzer;
using GPTTextGenerator.Infrastructure.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTTextGenerator.Infrastructure.Helpers
{
    public static class DialogueHelper
    {
        public static string GenerateBasicSteppedDialogueRequest(this SmartNPC npc, DialogueNode prevNode, int variety)
            => new Preprocessor().GenerateBasicSteppedDialogueRequest(npc, prevNode, variety);

        public static string GenerateBasicBranchedDialogueRequest(this SmartNPC npc, int depth, int variety)
            => new Preprocessor().GenerateBasicBranchedDialogueRequest(npc, depth, variety);

        public static string GenerateIntroductoryPhraseRequest(this SmartNPC npc)
            => new Preprocessor().GenerateIntroductoryPhraseRequest(npc);

        public static List<DialogueNode> DecodeAPISteppedDialogueResponse(this SmartNPC npc, string prevNodeKey, string response)
            => new Postprocessor().DecodeAPISteppedDialogueResponse(npc, prevNodeKey, response);

        public static DialogueEntry DecodeAPIBranchedDialogueResponse(this SmartNPC npc, string response)
            => new Postprocessor().DecodeAPIBranchedDialogueResponse(npc, response);

        public static List<string> GetAllDialogueBranches(this DialogueEntry entry)
            => new List<string>();

        public static bool CheckDialogueCorrection(this List<string> dialogueBranches)
            => true;
    }
}
