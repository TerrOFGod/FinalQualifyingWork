namespace TextGenerator.Core.Interfaces.Memory;

/// <summary>
/// Генератор векторных представлений (эмбеддингов) для текста.
/// </summary>
public interface IEmbeddingGenerator
{
    /// <summary>Получить эмбеддинг для заданного текста.</summary>
    float[] GetEmbedding(string text);
}