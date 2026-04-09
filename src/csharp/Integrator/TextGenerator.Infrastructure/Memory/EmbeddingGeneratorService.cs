using AllMiniLmL6V2Sharp;
using TextGenerator.Core.Interfaces.Memory;

namespace TextGenerator.Infrastructure.Memory;

/// <summary>
/// Генератор эмбеддингов с помощью ONNX-модели (например, all-MiniLM-L6-v2).
/// </summary>
public class EmbeddingGeneratorService : IEmbeddingGenerator
{
    private readonly AllMiniLmL6V2Embedder _embedder;

    public EmbeddingGeneratorService()
    {
        _embedder = new AllMiniLmL6V2Embedder("models/all-MiniLM-L6-v2/model.onnx");
    }

    public float[] GetEmbedding(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return Array.Empty<float>();

        // Генерация эмбеддинга для одного предложения
        var embedding = _embedder.GenerateEmbedding(text);
        return embedding.ToArray();
    }
}