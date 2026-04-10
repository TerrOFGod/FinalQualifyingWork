using LLama;
using LLama.Common;
using Microsoft.Extensions.Options;
using System.Text;
using LLama.Sampling;
using Microsoft.VisualStudio.Threading;
using TextGenerator.Core.Interfaces.EdgeAI;

namespace TextGenerator.Infrastructure.EdgeAI;

/// <summary>
/// Клиент для локальной LLama-модели (GGUF).
/// </summary>
public class LocalLLMClient : ILLMClient
{
    private readonly AsyncLazy<InteractiveExecutor> _executor;
    private readonly LLamaSharpOptions _options;

    public LocalLLMClient(IOptions<LLamaSharpOptions> options, JoinableTaskContext joinableTaskContext)
    {
        _options = options.Value;
        _executor = new AsyncLazy<InteractiveExecutor>(
            async () => await LoadModelAsync(_options.ModelPath),
            joinableTaskContext.Factory);
    }
    
    private async Task<InteractiveExecutor> LoadModelAsync(string modelPath)
    {
        var parameters = new ModelParams(modelPath)
        {
            ContextSize = _options.ContextSize,
            GpuLayerCount = _options.GpuLayerCount,   // 0 = CPU, >0 = GPU
            BatchSize = _options.BatchSize
        };
        var model = await Task.Run(() => LLamaWeights.LoadFromFile(parameters));
        var context = model.CreateContext(parameters);
        return new InteractiveExecutor(context);
    }

    public async Task<string> GenerateAsync(string prompt, int maxTokens = 256, float temperature = 0.7f)
    {
        var executor = await _executor.GetValueAsync();
        
        var inferenceParams = new InferenceParams
        {
            MaxTokens = maxTokens,
            AntiPrompts = new[] { "\nPlayer:", "\nNPC:" },
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