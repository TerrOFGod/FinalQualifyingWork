using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Interfaces.Processors
{
    /// <summary>
    /// Построение промптов для различных типов генерации (диалоги, квесты).
    /// </summary>
    public interface ILLMPromptBuilder
    {
        /// <summary>Промпт для генерации ветвистого диалога с заданной глубиной и вариативностью.</summary>
        Task<string> BuildBranchedDialoguePromptAsync(SmartNPC npc, int depth, int variety);
        
        /// <summary>Промпт для генерации квеста на основе описания цели.</summary>
        Task<string> BuildQuestPromptAsync(SmartNPC npc, Player player, string goalDescription);
        
        /// <summary>Промпт для генерации следующего шага диалога с учётом предыдущего узла.</summary>
        Task<string> BuildSteppedDialoguePromptAsync(SmartNPC npc, DialogueNode prevNode, int variety, WorldContext context);
        Task<string> BuildIntroductoryPhrasePromptAsync(SmartNPC npc);
    }
}
