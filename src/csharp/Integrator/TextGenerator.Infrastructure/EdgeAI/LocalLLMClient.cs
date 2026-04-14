using LLama;
using LLama.Common;
using Microsoft.Extensions.Options;
using System.Text;
using LLama.Sampling;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Threading;
using TextGenerator.Core.Interfaces.EdgeAI;

namespace TextGenerator.Infrastructure.EdgeAI;

/// <summary>
/// Клиент для локальной LLama-модели (GGUF).
/// </summary>
public class LocalLLMClient : ILLMClient
{
    private readonly LLamaWeights _weights;
    private readonly LLamaContext _context;
    private readonly LLamaSharpOptions _options;
    private readonly ILogger<LocalLLMClient> _logger;
    private readonly InteractiveExecutor _executor;

    public LocalLLMClient(IOptions<LLamaSharpOptions> options, ILogger<LocalLLMClient> logger)
    {
        _options = options.Value;
        _logger = logger;
        
        var modelPath = GetModelPath("Meta-Llama-3-8B-Instruct.Q4_K_M.gguf");
        _logger.LogInformation("Loading model from {ModelPath}", modelPath);
        
        var parameters = new ModelParams(modelPath)
        {
            ContextSize = _options.ContextSize,
            GpuLayerCount = _options.GpuLayerCount,
            BatchSize = _options.BatchSize
        };
        
        _weights = LLamaWeights.LoadFromFile(parameters);
        _context = _weights.CreateContext(parameters);
        _executor = new InteractiveExecutor(_context);
        _logger.LogInformation("Model loaded successfully");
    }
    
    // private InteractiveExecutor LoadModelAsync(string modelPath)
    // {
    //     _logger.LogInformation("Loading model from {ModelPath}", modelPath);
    //     var parameters = new ModelParams(modelPath)
    //     {
    //         ContextSize = _options.ContextSize,
    //         GpuLayerCount = _options.GpuLayerCount,   // 0 = CPU, >0 = GPU
    //     };
    //     using var model = LLamaWeights.LoadFromFile(parameters);
    //     using var context = model.CreateContext(parameters);
    //     _logger.LogInformation("Model loaded successfully");
    //     return new InteractiveExecutor(context);
    // }

    public async Task<string> GenerateAsync(string prompt, int maxTokens = 256, float temperature = 0.7f)
        => await GenerateWithSystemAsync(prompt, string.Empty, maxTokens, temperature);
    
    public async Task<string> GenerateWithSystemAsync(string prompt, string systemPrompt, int maxTokens = 256, float temperature = 0.7f)
    {
        var chatHistory = new ChatHistory();
        
        // Добавляем системное сообщение, если оно задано
        if (!string.IsNullOrWhiteSpace(systemPrompt))
            chatHistory.AddMessage(AuthorRole.System, systemPrompt);
        
        var session = new ChatSession(_executor, chatHistory);
        
        var inferenceParams = new InferenceParams
        {
            MaxTokens = maxTokens,
            AntiPrompts = new[] { "User:" },// "Player:", "NPC:", "\n\n" }, // остановка при появлении меток игрока или пустой строки
            SamplingPipeline = new DefaultSamplingPipeline
            {
                TopP = 0.95f,
                RepeatPenalty = 1.0f,
                Temperature = temperature
            }
        };
        
        var result = new StringBuilder();
        
        await foreach (var text in session.ChatAsync(new ChatHistory.Message(AuthorRole.User, prompt), inferenceParams))
        {
            result.Append(text);
        }
        
        return result.ToString().Trim();
    }
    
    private string GetModelPath(string model)
    {
        var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        // Пытаемся найти модель в папке models относительно исполняемого файла
        var relativePath = Path.Combine(baseDir, "models", model);
        if (File.Exists(relativePath))
            return relativePath;
    
        // Запасной вариант: ищем на два уровня выше (корень решения)
        var solutionRoot = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName;
        var absolutePath = Path.Combine(solutionRoot, "models", model);
        if (File.Exists(absolutePath))
            return absolutePath;
    
        throw new FileNotFoundException($"Модель не найдена ни по пути {relativePath}, ни по {absolutePath}");
    }
}