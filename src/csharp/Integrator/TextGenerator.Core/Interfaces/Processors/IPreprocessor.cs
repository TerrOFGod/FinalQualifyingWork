using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Interfaces.Processors;

/// <summary>
/// Построение промптов для различных типов генерации (диалоги, квесты).
/// </summary>
public interface IPreprocessor
{
    /// <summary>
    /// Генерация промпта для разветвлённого диалога (одним запросом)
    /// </summary>
    string BuildBranchedDialoguePrompt(SmartNPC npc, int? depth, int variety);
    
    /// <summary>
    /// Генерация промпта для пошагового диалога (step-by-step)
    /// </summary>
    string BuildSteppedDialoguePrompt(SmartNPC npc, DialogueNode? prevNode, int variety, WorldContext context);
    
    /// <summary>
    /// Генерация промпта для квеста
    /// </summary>
    string BuildQuestPrompt(SmartNPC npc, Player player, string goalDescription);
    
    /// <summary>
    /// Генерация вступительной фразы NPC
    /// </summary>
    string BuildIntroductoryPhrasePrompt(SmartNPC npc);
}