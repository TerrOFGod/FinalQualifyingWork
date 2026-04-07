using System.Text;
using TextGenerator.Core.Interfaces.Memorize;
using TextGenerator.Infrastructure.Memory;

namespace TextGenerator.Infrastructure.RAG;

public class RAGService
{
    private readonly IMemory _memory;
    private readonly VectorMemoryService _vectorizer;

    public RAGService(IMemory memory, VectorMemoryService vectorizer)
    {
        _memory = memory;
        _vectorizer = vectorizer;
    }

    public async Task<string> AugmentPrompt(string userQuery, string basePrompt)
    {
        var embedding = _vectorizer.GetEmbedding(userQuery);
        var memories = await _memory.RetrieveRelevant(userQuery, embedding, topK: 3);
        if (memories.Count == 0) return basePrompt;

        var context = new StringBuilder();
        context.AppendLine("Вот что NPC помнит о прошлых взаимодействиях:");
        foreach (var mem in memories)
            context.AppendLine($"- {mem.Text}");

        return $"{basePrompt}\n\n{context}\nОтветь, учитывая эту память.";
    }

    public async Task StoreInteraction(string text, string metadata)
    {
        var embedding = _vectorizer.GetEmbedding(text);
        await _memory.AddMemory(text, embedding, metadata);
    }
}