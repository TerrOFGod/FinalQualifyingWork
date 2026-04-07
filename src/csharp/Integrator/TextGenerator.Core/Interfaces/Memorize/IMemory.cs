namespace TextGenerator.Core.Interfaces.Memorize;

public interface IMemory
{
    Task AddMemory(string text, float[] embedding, string metadata);
    Task<List<(string Text, float Score)>> RetrieveRelevant(string query, float[] queryEmbedding, int topK = 5);
}