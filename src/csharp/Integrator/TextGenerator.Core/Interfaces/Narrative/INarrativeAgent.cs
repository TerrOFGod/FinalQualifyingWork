using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Core.Interfaces.Narrative;

/// <summary>
/// Основной генератор диалогов и квестов на основе LLM, памяти и контекста мира.
/// </summary>
public interface INarrativeAgent
{
    /// <summary>Сгенерировать ветку диалога для заданного NPC и игрока.</summary>
    Task<DialogueEntry> GenerateDialogue(SmartNPC npc, Player player, string playerInput, int depth, int variety);
    
    /// <summary>Сгенерировать квест на основе описания цели.</summary>
    Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription);
}