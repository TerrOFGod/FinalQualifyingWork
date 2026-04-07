using TextGenerator.Core.Interfaces.Memorize;

namespace TextGenerator.Infrastructure.Reward;

public class RewardCalculator : IRewardSystem
{
    private readonly Analyzer.Analyzer _analyzer;

    public RewardCalculator(Analyzer.Analyzer analyzer) => _analyzer = analyzer;

    public float CalculateReward(string generatedText, string context, string expectedStyle)
    {
        // 1. Синтаксическая корректность (0-1)
        float syntaxScore = _analyzer.CheckCorrections(new List<string> { generatedText }) ? 1.0f : 0.3f;

        // 2. Семантическая согласованность (упрощённо: проверка наличия ключевых слов контекста)
        float contextScore = context.Contains(generatedText[..Math.Min(50, generatedText.Length)]) ? 0.8f : 0.5f;

        // 3. Стилистическое соответствие (имитация)
        float styleScore = generatedText.Contains(expectedStyle) ? 1.0f : 0.4f;

        // Итоговая награда (можно настраивать веса)
        return (syntaxScore * 0.4f + contextScore * 0.3f + styleScore * 0.3f);
    }
}