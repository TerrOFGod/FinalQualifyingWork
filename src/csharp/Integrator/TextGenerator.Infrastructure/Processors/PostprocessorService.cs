using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;
using TextGenerator.Infrastructure.Extensions;

namespace TextGenerator.Infrastructure.Processors
{
    public class PostprocessorService : IPostprocessor
    {
        private static string npcName = "";
        private static string playerName = "";

        public List<DialogueNode> DecodeAPISteppedDialogueResponse(SmartNPC npc, string prevNodeKey, string response)
        { 
            List<DialogueNode> dialogueNodes = new List<DialogueNode>();

            var result = ParseTextToDict(response);

            foreach (var line in result)
            {
                var node = new DialogueNode();
                node.Name = prevNodeKey == "" ? line.Key : prevNodeKey + line.Key;
                node.Childs = new List<DialogueNode>();
                node.InterlocutorNPC = npcName;
                node.NPCText = line.Value[npcName]["NPC"];
                node.InterlocutorPlayer = playerName;
                node.PlayerText = line.Value[playerName]["Player"];
                var level = line.Key.Split('.', (char)StringSplitOptions.RemoveEmptyEntries).Length;
                //Console.WriteLine(level);

                dialogueNodes.Add(node);
            }

            return dialogueNodes;
        }

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
                var level = line.Key.Split('.', (char)StringSplitOptions.RemoveEmptyEntries).Length;
                //Console.WriteLine(level);

                if (level - 1 == 0)
                {
                    dialogueEntry.AddChildToEntry(node);
                }
                else
                {
                    var parent = dialogueEntry.GetDialogueNodeByName(line.Key.Remove(line.Key.Length - 2));
                    parent.AddChildToNode(node);
                }
            }

            return dialogueEntry;
        }

        public Quest ParseQuest(string response)
        {
            // Извлечь JSON из ответа (модель может добавить пояснения)
            var jsonMatch = Regex.Match(response, @"\{[\s\S]*\}");
            if (!jsonMatch.Success) throw new ArgumentException("No JSON found");
            var quest = JsonConvert.DeserializeObject<Quest>(jsonMatch.Value);
            // Валидация полей
            if (quest.Difficulty < 1 || quest.Difficulty > 5) quest.Difficulty = 3;
            return quest;
        }

        private DialogueNode ParseBranch(string separator)
        {
            DialogueNode branch = new DialogueNode();
            return branch;
        }
        
        public DialogueNode DecodeSingleStepDialogueResponse(SmartNPC npc, string response)
        {
            // Парсим строку вида: "Игрок: \"...\" NPC: \"...\""
            var pattern = @"Игрок:\s*""(?<player>[^""]+)""\s+NPC:\s*""(?<npc>[^""]+)""";
            var match = Regex.Match(response, pattern);
            if (!match.Success) throw new FormatException("Invalid stepped response");
    
            return new DialogueNode
            {
                InterlocutorPlayer = "Игрок",
                PlayerText = match.Groups["player"].Value,
                InterlocutorNPC = npc.Name,
                NPCText = match.Groups["npc"].Value,
                Childs = new List<DialogueNode>()
            };
        }

        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> ParseTextToDict(string text)
        {
            string pattern = @"(?<variant>\d.)\s+(?<playerName>\w+)\s*:\s*""(?<playerPhrase>[^""]+)""\s+(?<npcName>\w+)\s*:\s*""(?<npcPhrase>[^""]+)""";
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.Singleline);

            Dictionary<string, Dictionary<string, Dictionary<string, string>>> groups = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

            foreach (Match match in matches)
            {
                string key = match.Groups["variant"].Value;
                npcName = match.Groups["npcName"].Value;
                string npcPhrase = match.Groups["npcPhrase"].Value;
                playerName = match.Groups["playerName"].Value;
                string playerPhrase = match.Groups["playerPhrase"].Value;

                if (!groups.ContainsKey(key))
                {
                    groups[key] = new Dictionary<string, Dictionary<string, string>>();
                }

                if (!groups[key].ContainsKey(playerName))
                {
                    groups[key][playerName] = new Dictionary<string, string>();
                }
                groups[key][playerName]["Player"] = playerPhrase;

                if (!groups[key].ContainsKey(npcName))
                {
                    groups[key][npcName] = new Dictionary<string, string>();
                }
                groups[key][npcName]["NPC"] = npcPhrase;
            }

            return groups;
        }
    }
}