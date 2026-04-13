using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Feedback;

public class InteractionFeedback : IEntity
{
    public string Prompt { get; set; }
    public string GeneratedResponse { get; set; }
    public float Reward { get; set; }
    public Dictionary<string, float> Metrics { get; set; } = new();
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        
    // Дополнительные поля для сбора неявной обратной связи
    public int PlayerChoiceIndex { get; set; } = -1;      // какую ветку выбрал игрок
    public double TimeToRespondMs { get; set; }           // время чтения/выбора
    public bool QuestAccepted { get; set; }               // для квестов
    public TimeSpan QuestCompletionTime { get; set; }     // время выполнения квеста
    public Guid Id { get; } = Guid.NewGuid();
}