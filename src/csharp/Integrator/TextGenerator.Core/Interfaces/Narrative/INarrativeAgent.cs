using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Core.Interfaces.Narrative;

public interface INarrativeAgent
{
    Task<DialogueEntry> GenerateDialogue(SmartNPC npc, Player player, string playerInput, int depth, int variety);
    Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription);
}