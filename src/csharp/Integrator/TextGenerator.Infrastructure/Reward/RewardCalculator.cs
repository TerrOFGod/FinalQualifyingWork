using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Processors;

namespace TextGenerator.Infrastructure.Reward;

/// <summary>
/// Вычисление награды для сгенерированной реплики на основе валидации, контекста и стиля.
/// </summary>
public class RewardCalculator : IRewardCalculator
{
    private readonly IDialogueValidator _dialogueDialogueValidator;

    public RewardCalculator(IDialogueValidator dialogueDialogueValidator) => _dialogueDialogueValidator = dialogueDialogueValidator;

    public float CalculateReward(string generatedText, string context, string expectedStyle)
    {
        // 1. Syntactic correctness (0-1)
        float syntaxScore = _dialogueDialogueValidator.CheckCorrections(new List<string> { generatedText }) ? 1.0f : 0.3f;

        // 2. Semantic consistency (simplified: check for presence of context keywords)
        float contextScore = context.Contains(generatedText[..Math.Min(50, generatedText.Length)]) ? 0.8f : 0.5f;

        // 3. Stylistic conformity (imitation)
        float styleScore = generatedText.Contains(expectedStyle) ? 1.0f : 0.4f;

        // Final reward (weights can be tuned)
        return (syntaxScore * 0.4f + contextScore * 0.3f + styleScore * 0.3f);
    }
}