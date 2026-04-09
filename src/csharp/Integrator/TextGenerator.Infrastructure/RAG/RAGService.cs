using System.Text;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.RAG;

namespace TextGenerator.Infrastructure.RAG;

/// <summary>
/// Реализация RAG-усиления промпта: извлечение релевантных воспоминаний и их добавление.
/// </summary>
public class RAGService : IRAGService
{
    private readonly IVectorMemoryStore _vectorMemoryStore;
    private readonly IEmbeddingGenerator _vectorizer;
    private readonly ITextSummarizer _textSummarizer;

    public RAGService(IVectorMemoryStore vectorMemoryStore, IEmbeddingGenerator vectorizer, ITextSummarizer textSummarizer)
    {
        _vectorMemoryStore = vectorMemoryStore;
        _vectorizer = vectorizer;
        _textSummarizer = textSummarizer;
    }

    public async Task<string> AugmentPrompt(string userQuery, string basePrompt)
    {
        var embedding = _vectorizer.GetEmbedding(userQuery);
        var memories = await _vectorMemoryStore.RetrieveRelevantWithTimestamp(userQuery, embedding, topK: 3);
    
        if (memories.Count == 0) return basePrompt;
    
        var sorted = memories.OrderByDescending(m => m.Timestamp).Take(3);

        var context = new StringBuilder();
        context.AppendLine("Here is what the NPC remembers about past interactions (recent memories are more important):");
        foreach (var mem in memories)
            context.AppendLine($"- {mem.Text} ({DateTime.Now.Subtract(mem.Timestamp).TotalHours:F1} hours ago)");

        var fullPrompt = $"{basePrompt}\n\n{context}";

        if (EstimateTokenCount(fullPrompt) <= 1800) return fullPrompt;
        
        var summary = await _textSummarizer.Summarize(context.ToString());
        return $"{basePrompt}\n\nBrief reminder: {summary}";
    }

    public async Task StoreInteraction(string text, string metadata)
    {
        var embedding = _vectorizer.GetEmbedding(text);
        await _vectorMemoryStore.AddMemory(text, embedding, metadata);
    }
    
    private int EstimateTokenCount(string text)
    {
        // Простая эвристика: 1 токен ≈ 4 символов для английского, 2 символа для кириллицы.
        // В реальном проекте используйте настоящий токенизатор (например, LLamaSharp's Tokenizer).
        return (int)(text.Length * 0.75);
    }
}