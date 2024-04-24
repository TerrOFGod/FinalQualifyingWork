using MainPlugin.Core.Entities.Interfaces.Processors;
using MainPlugin.Core.Entities.Models.Interactions;
using MainPlugin.Core.Entities.Models.Interactors;
using MainPlugin.Infrastructure.Extensions;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MainPlugin.Infrastructure.Processors
{
    public class Postprocessor : IPostprocessor
    {
        public DialogueEntry DecodeAPIResponse(SmartNPC npc, string response)
        {
            DialogueEntry dialogueEntry = new DialogueEntry();
            dialogueEntry.Childs = new List<DialogueNode>();

            // Split inputText into individual dialogue entries
            string[] entries = response.Split(new string[] { "Уровень 1" }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"(?<=\""(?>[^\""\\]++|\\.)*\""\s*)(?<name>[^:]+):\s*(?<text>[^""\r\n]+)";

            MatchCollection matches = Regex.Matches(entries[0], pattern, RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                dialogueEntry.Text = match.Groups["text"].Value;
            }

            var dict = ParseTextToDict(entries[1]);
            var interlocutors = GetInterlocutors(entries[1]);

            foreach (var line in dict)
            {
                var node = new DialogueNode();
                node.Name = line.Key;
                node.Childs = new List<DialogueNode>();
                node.InterlocutorNPC = interlocutors.npc;
                node.NPCText = line.Value[interlocutors.npc];
                node.InterlocutorPlayer = interlocutors.player;
                node.PlayerText = line.Value[interlocutors.player];
                var level = line.Key.Split('.').Length;

                if (level - 1 == 0)
                {
                    dialogueEntry.AddChildToEntry(node);
                }
                else
                {
                    var parent = dialogueEntry.GetDialogueNodeByName(line.Key[..^2]);
                    parent.AddChildToNode(node);
                }
            }

            return dialogueEntry;
        }

        private DialogueNode ParseBranch(string separator)
        {
            DialogueNode branch = new();
            return branch;
        }

        private (string npc, string player) GetInterlocutors(string text)
        {
            var res = (npc: "", player: "");
            string pattern = @"(?<variant>\d(\.\d)*)\s(?<npcName>\w+):\s""(?<npcPhrase>.+)""\s(?<playerName>\w+):\s""(?<playerPhrase>.+)""";

            // Create a regular expression object
            Regex regex = new(pattern, RegexOptions.Singleline);

            // Match the pattern in the input string
            MatchCollection matches = regex.Matches(text);

            var list = new List<string>();

            foreach (Match match in matches)
            {
                string npcName = match.Groups["npcName"].Value;
                string playerName = match.Groups["playerName"].Value;
                if (!list.Contains(npcName))
                {
                    res.npc = npcName;
                    list.Add(npcName);
                }

                if (!list.Contains(playerName))
                {
                    res.player = playerName;
                    list.Add(playerName);
                }

                if( (res.npc != "") && (res.player != ""))
                {
                    break;
                }
            }

            return res;
        }

        private Dictionary<string, Dictionary<string, string>> ParseTextToDict(string text)
        {
            // Define the pattern to match digits followed by space and any name
            string pattern = @"(?<variant>\d(\.\d)*)\s(?<npcName>\w+):\s""(?<npcPhrase>.+)""\s(?<playerName>\w+):\s""(?<playerPhrase>.+)""";

            // Create a regular expression object
            Regex regex = new(pattern, RegexOptions.Singleline);

            // Match the pattern in the input string
            MatchCollection matches = regex.Matches(text);

            // Create a dictionary to store groups based on the number of digits
            Dictionary<string, Dictionary<string, string>> groups = new();

            // Iterate through the matches and group them based on the number of digits
            foreach (Match match in matches){
                string key = match.Groups["variant"].Value;
                string npcName = match.Groups["npcName"].Value;
                string npcPhrase = match.Groups["npcPhrase"].Value;
                string playerName = match.Groups["playerName"].Value;
                string playerPhrase = match.Groups["playerPhrase"].Value;

                if (!groups.ContainsKey(key)){
                    groups[key] = new();
                }

                groups[key].Add(npcName, npcPhrase);
                groups[key].Add(playerName, playerPhrase);
            }

            return groups;
        }
    }
}