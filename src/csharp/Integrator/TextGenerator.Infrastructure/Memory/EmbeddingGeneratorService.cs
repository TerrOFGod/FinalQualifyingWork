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
        // Получаем директорию, где находится исполняемый файл (TextGenerator.Service)
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var modelPath = Path.Combine(baseDirectory, "models", "all-MiniLM-L6-v2", "model.onnx");
            
        if (!File.Exists(modelPath))
            throw new FileNotFoundException($"Модель не найдена: {modelPath}");
            
        _embedder = new AllMiniLmL6V2Embedder(modelPath);
    }

    public float[] GetEmbedding(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return Array.Empty<float>();

        // Генерация эмбеддинга для одного предложения
        var embedding = _embedder.GenerateEmbedding(text);
        var arr = embedding.ToArray();
        Console.WriteLine($"Embedding generated for text: '{text.Substring(0, Math.Min(20, text.Length))}...', dimension: {arr.Length}");
        return arr;
    }
}