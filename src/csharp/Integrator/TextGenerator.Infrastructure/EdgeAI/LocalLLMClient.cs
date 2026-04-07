using LLama;
using LLama.Common;
using Microsoft.Extensions.Options;
using System.Text;
using LLama.Sampling;

namespace TextGenerator.Infrastructure.EdgeAI;

public class LocalLLMClient
{
    private readonly InteractiveExecutor _executor;
    private readonly LLamaContext _context;

    public LocalLLMClient(IOptions<LLamaSharpOptions> options)
    {
        var modelPath = options.Value.ModelPath;
        var parameters = new ModelParams(modelPath)
        {
            ContextSize = 2048,
            GpuLayerCount = 20,   // использовать GPU
            BatchSize = 512
        };
        var model = LLamaWeights.LoadFromFile(parameters);
        _context = model.CreateContext(parameters);
        _executor = new InteractiveExecutor(_context);
    }

    public async Task<string> GenerateAsync(string prompt, int maxTokens = 256)
    {
        var inferenceParams = new InferenceParams
        {
            MaxTokens = maxTokens,
            AntiPrompts = new[] { "\nИгрок:", "\nNPC:" },
            SamplingPipeline = new DefaultSamplingPipeline
            {
                Temperature = 0.7f
            }
        };

        var result = new StringBuilder();

        await foreach (var token in _executor.InferAsync(prompt, inferenceParams))
        {
            result.Append(token);
        }

        return result.ToString();
    }
}

public class LLamaSharpOptions
{
    public string ModelPath { get; set; } = "models/llama-3-8b-q4.gguf";
}