using GPTTextGenerator.Entities.Models.Actions;
using GPTTextGenerator.Entities.Models.Interactions;
using GPTTextGenerator.Entities.Models.Interactors;
using GPTTextGenerator.Infrastructure.API;
using GPTTextGenerator.Infrastructure.Helpers;

string key = "sk-or-vv-cf448da6158b0c0215d461b7fefdd9465d76648a70ae54695421dbbdfa56c2c1";

SmartNPC npc = new();

npc.Name = "Альфред";
npc.Type = "Герой";
npc.Age = 35;
npc.Profession = "Рыцарь";
npc.Appearance = "cедые волосы, подтянутый, жилистый";
npc.PersonalCharacteristics = new List<string>() { "Добрый", "Отважный", "Честный" };
npc.SocialConnections = new List<SocialConnection>()
{
    new SocialConnection()
    {
        ID = 1,
        RelatedNPC = new SmartNPC() { Name = "Мария" },
        Type = "Супруга",
        Relationships = "Тесная"
    },
    new SocialConnection()
    {
        ID = 2,
        RelatedNPC = new SmartNPC() { Name = "Ричард" },
        Type = "Друг",
        Relationships = "Хорошая"
    }
};

npc.Behaviors = new List<string>() { "Агрессивный в бою", "Дружелюбный в общении" };

GptApiClient client = new GptApiClient(key, "https://api.vsegpt.ru/v1/", "anthropic/claude-3-haiku");

var requestString = npc.GenerateBasicBranchedDialogueRequest(2, 2);

string responseString;
DialogueEntry branchedDialogue;

do
{
    responseString = await client.SendRequest(requestString);
    branchedDialogue = npc.DecodeAPIBranchedDialogueResponse(responseString);
} while (!branchedDialogue.GetAllDialogueBranches().CheckDialogueCorrection());

void WriteDialogue(DialogueEntry entry)
{
    Console.WriteLine("Entry text: " + entry.Text);
    Console.WriteLine("Entry child count: " + entry.Childs.Count);
    Console.WriteLine("");
    foreach (var child in entry.Childs)
    {
        WriteDialogueNodeRecursive(child);
    }
}

void WriteDialogueNodeRecursive(DialogueNode node)
{
    Console.WriteLine("Dialogue varient: " + node.Name);
    Console.WriteLine("Player name: " + node.InterlocutorPlayer);
    Console.WriteLine("Player text: " + node.PlayerText);
    Console.WriteLine("NPC name: " + node.InterlocutorNPC);
    Console.WriteLine("NPC text: " + node.NPCText);
    Console.WriteLine("Dialogue node childs count: " + node.Childs.Count);
    Console.WriteLine("");
    if (node.Childs != null && node.Childs.Any())
    {
        foreach (var childNode in node.Childs)
        {
            WriteDialogueNodeRecursive(childNode);
        }
    }
}

WriteDialogue(branchedDialogue);