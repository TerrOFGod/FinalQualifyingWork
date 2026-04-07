using System.Text;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.RAG;

namespace TextGenerator.Infrastructure.RAG;

public class RAGService : IRAGService
{
    private readonly IMemory _memory;
    private readonly IVectorMemory _vectorizer;
    private readonly ISummarizer _summarizer;

    public RAGService(IMemory memory, IVectorMemory vectorizer, ISummarizer summarizer)
    {
        _memory = memory;
        _vectorizer = vectorizer;
        _summarizer = summarizer;
    }

    public async Task<string> AugmentPrompt(string userQuery, string basePrompt)
    {
        var embedding = _vectorizer.GetEmbedding(userQuery);
        // Получаем воспоминания с временными метками
        var memories = await _memory.RetrieveRelevantWithTimestamp(userQuery, embedding, topK: 3);
        
        if (memories.Count == 0) return basePrompt;
        
        // Сортируем по убыванию свежести (score уже учитывает косинусное сходство, но добавим временной коэффициент)
        var sorted = memories.OrderByDescending(m => m.Timestamp).Take(3);

        var context = new StringBuilder();
        context.AppendLine("Вот что NPC помнит о прошлых взаимодействиях (свежие воспоминания важнее):");
        foreach (var mem in memories)
            context.AppendLine($"- {mem.Text} (было {DateTime.Now.Subtract(mem.Timestamp).TotalHours:F1} ч. назад)");

        // Если общая длина промпта превышает лимит (например, 1800 токенов), вызываем суммаризатор
        var fullPrompt = $"{basePrompt}\n\n{context}";
        
        if (EstimateTokenCount(fullPrompt) > 1800)
        {
            var summary = await _summarizer.Summarize(context.ToString());
            fullPrompt = $"{basePrompt}\n\nКраткая памятка: {summary}";
        }
        return fullPrompt;
    }

    public async Task StoreInteraction(string text, string metadata)
    {
        var embedding = _vectorizer.GetEmbedding(text);
        await _memory.AddMemory(text, embedding, metadata);
    }
    
    private int EstimateTokenCount(string text)
    {
        // Простая эвристика: 1 токен ≈ 4 символов для английского, 2 символа для кириллицы.
        // В реальном проекте используйте настоящий токенизатор (например, LLamaSharp's Tokenizer).
        return (int)(text.Length * 0.75);
    }
}