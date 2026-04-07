using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Infrastructure.EdgeAI;

namespace TextGenerator.Infrastructure.Memory;

public class Summarizer : ISummarizer
{
    private readonly LocalLLMClient _llm;

    public Summarizer(LocalLLMClient llm) => _llm = llm;

    public async Task<string> Summarize(string longText)
    {
        var prompt = $"Кратко перескажи следующий диалог или событие (не более 2 предложений):\n{longText}";
        return await _llm.GenerateAsync(prompt, maxTokens: 100);
    }
}