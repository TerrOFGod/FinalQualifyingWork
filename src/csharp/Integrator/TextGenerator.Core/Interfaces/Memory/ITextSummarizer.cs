namespace TextGenerator.Core.Interfaces.Memory;

/// <summary>
/// Сервис для суммаризации длинных текстов с помощью LLM.
/// </summary>
public interface ITextSummarizer
{
    /// <summary>Создать краткий пересказ текста (не более 2-3 предложений).</summary>
    Task<string> Summarize(string longText);
}