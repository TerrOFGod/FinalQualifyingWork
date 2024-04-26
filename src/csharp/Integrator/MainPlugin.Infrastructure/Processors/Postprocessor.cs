using GPTTextGenerator.Entities.Interfaces.Processors;
using GPTTextGenerator.Entities.Models.Interactions;
using GPTTextGenerator.Entities.Models.Interactors;
using GPTTextGenerator.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GPTTextGenerator.Infrastructure.Processors
{
    public class Postprocessor : IPostprocessor
    {
        private static string npcName = "";
        private static string playerName = "";

        public DialogueEntry DecodeAPIBranchedDialogueResponse(SmartNPC npc, string response)
        {
            DialogueEntry dialogueEntry = new DialogueEntry();
            dialogueEntry.Childs = new List<DialogueNode>();

            string pattern = @"(?<variant>[0]{1})\s+(?<npcName>\w+)\s*:\s*""(?<npcPhrase>[^""]+)""";

            MatchCollection matches = Regex.Matches(response, pattern, RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                dialogueEntry.Text = match.Groups["npcPhrase"].Value;
            }

            var result = ParseTextToDict(response);
/*            foreach (var variant in result)
            {
                Console.WriteLine($"Вариант: {variant.Key}");
                foreach (var character in variant.Value)
                {
                    Console.WriteLine($"{character.Key}:");
                    foreach (var phrase in character.Value)
                    {
                        Console.WriteLine($"{phrase.Key}: {phrase.Value}");
                    }
                }
            }*/



            foreach (var line in result)
            {
                var node = new DialogueNode();
                node.Name = line.Key;
                node.Childs = new List<DialogueNode>();
                node.InterlocutorNPC = npcName;
                node.NPCText = line.Value[npcName]["NPC"];
                node.InterlocutorPlayer = playerName;
                node.PlayerText = line.Value[playerName]["Player"];
                var level = line.Key.Split('.', StringSplitOptions.RemoveEmptyEntries).Length;
                //Console.WriteLine(level);

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

        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> ParseTextToDict(string text)
        {
            string pattern = @"(?<variant>\d+(?:\.\d+)*)\s+(?<playerName>\w+)\s*:\s*""(?<playerPhrase>[^""]+)""\s+(?<npcName>\w+)\s*:\s*""(?<npcPhrase>[^""]+)""";
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.Singleline);

            Dictionary<string, Dictionary<string, Dictionary<string, string>>> groups = new();

            foreach (Match match in matches)
            {
                string key = match.Groups["variant"].Value;
                npcName = match.Groups["npcName"].Value;
                string npcPhrase = match.Groups["npcPhrase"].Value;
                playerName = match.Groups["playerName"].Value;
                string playerPhrase = match.Groups["playerPhrase"].Value;

                if (!groups.ContainsKey(key))
                {
                    groups[key] = new();
                }

                if (!groups[key].ContainsKey(playerName))
                {
                    groups[key][playerName] = new();
                }
                groups[key][playerName]["Player"] = playerPhrase;

                if (!groups[key].ContainsKey(npcName))
                {
                    groups[key][npcName] = new();
                }
                groups[key][npcName]["NPC"] = npcPhrase;
            }

            return groups;
        }
    }
}