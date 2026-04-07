using LLama;
using LLama.Common;
using Microsoft.Extensions.Options;
using System.Text;
using LLama.Sampling;
using TextGenerator.Core.Interfaces.EdgeAI;

namespace TextGenerator.Infrastructure.EdgeAI;

public class LocalLLMClient : ILLMClient
{
    private readonly Lazy<Task<InteractiveExecutor>> _executor;
    private readonly LLamaContext _context;

    public LocalLLMClient(IOptions<LLamaSharpOptions> options)
    {
        _executor = new Lazy<Task<InteractiveExecutor>>(() => LoadModelAsync(options.Value.ModelPath));
    }
    
    private async Task<InteractiveExecutor> LoadModelAsync(string modelPath)
    {
        var parameters = new ModelParams(modelPath)
        {
            ContextSize = 2048,
            GpuLayerCount = 20,   // использовать GPU
            BatchSize = 512
        };
        var model = await Task.Run(() => LLamaWeights.LoadFromFile(parameters));
        var context = model.CreateContext(parameters);
        return new InteractiveExecutor(context);
    }

    public async Task<string> GenerateAsync(string prompt, int maxTokens = 256, float temperature = 0.7f)
    {
        var executor = await _executor.Value;
        
        var inferenceParams = new InferenceParams
        {
            MaxTokens = maxTokens,
            AntiPrompts = new[] { "\nИгрок:", "\nNPC:" },
            SamplingPipeline = new DefaultSamplingPipeline
            {
                Temperature = temperature
            }
        };

        var result = new StringBuilder();

        await foreach (var token in executor.InferAsync(prompt, inferenceParams))
        {
            result.Append(token);
        }

        return result.ToString();
    }
}