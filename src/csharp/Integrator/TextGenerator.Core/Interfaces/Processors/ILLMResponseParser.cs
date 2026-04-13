using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Core.Interfaces.Processors
{
    /// <summary>
    /// Разбор ответов языковой модели в структурированные объекты (диалоги, квесты).
    /// </summary>
    public interface ILLMResponseParser
    {
        /// <summary>Разобрать ответ для ветвистого диалога (несколько вариантов).</summary>
        Task<DialogueNode> ParseBranchedDialogueResponse(SmartNPC npc, string response);
        
        /// <summary>Разобрать ответ для пошагового диалога (один следующий шаг).</summary>
        Task ParseSteppedDialogueResponse(SmartNPC npc, DialogueNode parentNode, string response);

        /// <summary>Разобрать JSON-ответ в объект квеста.</summary>
        Task<Quest> ParseQuestResponse(string response);
    }
}
