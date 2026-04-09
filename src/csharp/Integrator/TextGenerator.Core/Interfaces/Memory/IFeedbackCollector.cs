using TextGenerator.Core.Models.Feedback;

namespace TextGenerator.Core.Interfaces.Memory;

/// <summary>
/// Сбор и сохранение обратной связи от игрока/системы для последующего дообучения.
/// </summary>
public interface IFeedbackCollector
{
    /// <summary>Записать один эпизод обратной связи.</summary>
    void RecordFeedback(InteractionFeedback feedback);
    
    /// <summary>Получить весь накопленный датасет.</summary>
    Task<List<InteractionFeedback>> GetDatasetAsync();
    
    /// <summary>Сохранить датасет в JSON-файл.</summary>
    Task SaveToDatasetAsync(string path);
}