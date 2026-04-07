using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace TextGenerator.Infrastructure.Memory;

public class VectorMemoryService
{
    private readonly InferenceSession _embeddingSession;

    public VectorMemoryService(string embeddingModelPath = "all-MiniLM-L6-v2.onnx")
    {
        _embeddingSession = new InferenceSession(embeddingModelPath);
    }

    public float[] GetEmbedding(string text)
    {
        var tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Take(128).ToArray();
        var input = string.Join(" ", tokens);
        var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input_ids",
                new DenseTensor<long>(new long[] { 1, input.Length }, new[] { 1, input.Length }))
        };
        using var results = _embeddingSession.Run(inputs);
        var embedding = results.First().AsTensor<float>().ToArray();
        return embedding;
    }
}