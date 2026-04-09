namespace TextGenerator.Core.Interfaces.Memory;

/// <summary>
/// Хранилище векторной памяти (например, Qdrant) с возможностью поиска по сходству.
/// </summary>
public interface IVectorMemoryStore
{
    /// <summary>Добавить текст с его эмбеддингом и метаданными.</summary>
    Task AddMemory(string text, float[] embedding, string metadata);
    
    /// <summary>Найти topK наиболее релевантных записей.</summary>
    Task<List<(string Text, float Score)>> RetrieveRelevant(string query, float[] queryEmbedding, int topK = 5);

    /// <summary>Найти записи с временными метками.</summary>
    Task<List<(string Text, float Score, DateTime Timestamp)>> RetrieveRelevantWithTimestamp(string query,
        float[] queryEmbedding, int topK);
}