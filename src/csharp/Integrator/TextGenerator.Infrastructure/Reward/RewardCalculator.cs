using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Processors;

namespace TextGenerator.Infrastructure.Reward;

public class RewardCalculator : IRewardCalculator
{
    private readonly IAnalyzer _dialogueAnalyzer;

    public RewardCalculator(IAnalyzer dialogueAnalyzer) => _dialogueAnalyzer = dialogueAnalyzer;

    public float CalculateReward(string generatedText, string context, string expectedStyle)
    {
        // 1. Синтаксическая корректность (0-1)
        float syntaxScore = _dialogueAnalyzer.CheckCorrections(new List<string> { generatedText }) ? 1.0f : 0.3f;

        // 2. Семантическая согласованность (упрощённо: проверка наличия ключевых слов контекста)
        float contextScore = context.Contains(generatedText[..Math.Min(50, generatedText.Length)]) ? 0.8f : 0.5f;

        // 3. Стилистическое соответствие (имитация)
        float styleScore = generatedText.Contains(expectedStyle) ? 1.0f : 0.4f;

        // Итоговая награда (можно настраивать веса)
        return (syntaxScore * 0.4f + contextScore * 0.3f + styleScore * 0.3f);
    }
}