using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Infrastructure.EdgeAI;

namespace TextGenerator.Infrastructure.Memory;

/// <summary>
/// Суммаризация текста через локальную LLM.
/// </summary>
public class TextSummarizer : ITextSummarizer
{
    private readonly LocalLLMClient _llm;

    public TextSummarizer(LocalLLMClient llm) => _llm = llm;

    public async Task<string> Summarize(string longText)
    {
        var prompt = $"Кратко перескажи следующий диалог или событие (не более 2 предложений):\n{longText}";
        return await _llm.GenerateAsync(prompt, maxTokens: 100);
    }
}