using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Core.Interfaces.Processors;

/// <summary>
/// Разбор ответов языковой модели в структурированные объекты (диалоги, квесты).
/// </summary>
public interface IPostprocessor
{
    /// <summary>
    /// Парсит ответ LLM в древовидную структуру диалога
    /// </summary>
    DialogueNode ParseBranchedDialogueResponse(SmartNPC npc, string rawResponse);
    
    /// <summary>
    /// Парсит ответ LLM для одного шага диалога
    /// </summary>
    void ParseSteppedDialogueResponse(SmartNPC npc, DialogueNode parentNode, string rawResponse);
    
    /// <summary>
    /// Парсит ответ LLM в объект Quest
    /// </summary>
    Quest ParseQuestResponse(string rawResponse);
}