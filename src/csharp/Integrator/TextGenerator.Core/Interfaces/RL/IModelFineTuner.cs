namespace TextGenerator.Core.Interfaces.RL;

/// <summary>
/// Периодическое дообучение языковой модели на собранных данных обратной связи (RLHF/DPO).
/// </summary>
public interface IModelFineTuner
{
    /// <summary>Запустить процесс дообучения, если накоплено достаточно данных.</summary>
    Task RunPeriodicFineTuningAsync();
}