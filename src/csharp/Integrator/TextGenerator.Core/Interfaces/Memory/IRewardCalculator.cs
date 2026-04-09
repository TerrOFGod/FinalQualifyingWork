namespace TextGenerator.Core.Interfaces.Memory;

/// <summary>
/// Оценка качества сгенерированной реплики диалога (награда для RL).
/// </summary>
public interface IRewardCalculator
{
    /// <summary>Вычислить награду на основе сгенерированного текста, контекста и ожидаемого стиля.</summary>
    float CalculateReward(string generatedText, string context, string expectedStyle);
}