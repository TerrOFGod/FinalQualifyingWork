namespace TextGenerator.Core.Interfaces.EdgeAI;

/// <summary>
/// Клиент для взаимодействия с локальной языковой моделью (LLM).
/// </summary>
public interface ILLMClient
{
    /// <summary>Асинхронная генерация текста на основе промпта.</summary>
    /// <param name="prompt">Входной промпт.</param>
    /// <param name="maxTokens">Максимальное количество токенов в ответе.</param>
    /// <param name="temperature">Температура (случайность) генерации.</param>
    Task<string> GenerateAsync(string prompt, int maxTokens = 256, float temperature = 0.7f);
}