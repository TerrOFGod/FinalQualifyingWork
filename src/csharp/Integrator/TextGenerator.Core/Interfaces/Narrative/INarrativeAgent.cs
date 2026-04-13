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
    Task<DialogueNode> GenerateDialogue(SmartNPC npc, Player player, DialogueNode? parentNode, int? depth, int variety);
    
    /// <summary>Сгенерировать квест на основе описания цели.</summary>
    Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription);

    /// <summary>Генерация диалога без указания родительского узла и глубины (stepped mode, depth=null). Генерация root.</summary>
    Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        int variety);

    /// <summary>Генерация диалога с указанием родительского узла, но без глубины (stepped mode)</summary>
    public Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        DialogueNode parentNode,
        int variety);

    /// <summary>Генерация диалога с указанием глубины, но без родительского узла (branched mode)</summary>
    public Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        int? depth,
        int variety);
}