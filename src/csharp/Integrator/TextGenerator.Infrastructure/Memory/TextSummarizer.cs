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
        var prompt = $"Briefly retell the following dialogue or event (no more than 2 sentences):\n{longText}";
        return await _llm.GenerateAsync(prompt, maxTokens: 100);
    }
}