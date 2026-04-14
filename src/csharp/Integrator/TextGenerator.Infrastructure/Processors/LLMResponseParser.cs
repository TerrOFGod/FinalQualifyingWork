using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;
using TextGenerator.Infrastructure.Extensions;

namespace TextGenerator.Infrastructure.Processors;

/// <summary>
/// Парсинг ответов LLM в объекты диалогов и квестов.
/// </summary>
public class LLMResponseParser : ILLMResponseParser
{
    private static string npcName = "";
    private static string playerName = "";

    public async Task<DialogueNode> ParseBranchedDialogueResponse(SmartNPC npc, string response)
    {
        var root = new DialogueNode();
        root.Childs = new List<DialogueNode>();

        string pattern = @"(?<variant>[0]{1})\s+(?<npcName>\w+)\s*:\s*""(?<npcPhrase>[^""]+)""";

        MatchCollection matches = Regex.Matches(response, pattern, RegexOptions.Singleline);

        foreach (Match match in matches)
        {
            root.NPCText = match.Groups["npcPhrase"].Value;
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
                root.AddChild(node);
            }
            else
            {
                var parent = root.GetDialogueNodeByName(line.Key.Remove(line.Key.Length - 2));
                parent.AddChild(node);
            }
        }

        return root;
    }

    public async Task<Quest> ParseQuestResponse(string response)
    {
        // Извлечь JSON из ответа (модель может добавить пояснения)
        var jsonMatch = Regex.Match(response, @"\{[\s\S]*\}");
        if (!jsonMatch.Success) throw new ArgumentException("No JSON found");
        
        var quest = JsonConvert.DeserializeObject<Quest>(jsonMatch.Value);
        // Валидация полей
        if (quest!.Difficulty < 1 || quest.Difficulty > 5) quest.Difficulty = 3;
        return quest;
    }

    public async Task ParseSteppedDialogueResponse(SmartNPC npc, DialogueNode parentNode, string response)
    {
        // Экранируем имя NPC на случай спецсимволов (например, точка в "Dr. Smith")
        string escapedName = Regex.Escape(npc.Name);
    
        // Паттерн: номер. Player: "текст" (любые пробелы/переносы) (NPC|ИмяNPC): "текст"
        string pattern = $@"\d+\.\s*Player:\s*""(?<player>[^""]+)""\s+(?:NPC|{escapedName}):\s*""(?<npcText>[^""]+)""";
        var matches = Regex.Matches(response, pattern, RegexOptions.Multiline);
    
        if (matches.Count == 0)
            throw new FormatException($"No valid stepped responses found in: {response}");
    
        foreach (Match match in matches)
        {
            var childNode = new DialogueNode
            {
                InterlocutorPlayer = "Player",
                PlayerText = match.Groups["player"].Value,
                InterlocutorNPC = npc.Name,
                NPCText = match.Groups["npcText"].Value,
                Childs = new List<DialogueNode>() // дочерние узлы для будущих шагов
            };
            parentNode.AddChild(childNode);
        }
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