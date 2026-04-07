using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Memorize;

public interface INarrativeAgent
{
    Task<DialogueEntry> GenerateDialogue(SmartNPC npc, Player player, string playerInput, int depth, int variety);
    Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription);
}