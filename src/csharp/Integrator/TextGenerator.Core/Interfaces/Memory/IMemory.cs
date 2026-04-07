namespace TextGenerator.Core.Interfaces.Memory;

public interface IMemory
{
    Task AddMemory(string text, float[] embedding, string metadata);
    Task<List<(string Text, float Score)>> RetrieveRelevant(string query, float[] queryEmbedding, int topK = 5);

    Task<List<(string Text, float Score, DateTime Timestamp)>> RetrieveRelevantWithTimestamp(string query,
        float[] queryEmbedding, int topK);
}