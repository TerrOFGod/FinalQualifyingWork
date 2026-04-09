using TextGenerator.Core.Interfaces.EdgeAI;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.RL;

namespace TextGenerator.Infrastructure.RL;

/// <summary>
/// Периодическое дообучение модели на собранных данных.
/// </summary>
public class ModelFineTuner : IModelFineTuner
{
    private readonly IFeedbackCollector _collector;
    private readonly ILLMClient _llm;
    
    public ModelFineTuner(IFeedbackCollector collector, ILLMClient llm)
    {
        _collector = collector;
        _llm = llm;
    }
    
    public async Task RunPeriodicFineTuningAsync()
    {
        // 1. Собрать накопленные данные (prompt, response, reward)
        var dataset = await _collector.GetDatasetAsync();
        if (dataset.Count < 100) return;
        
        // 2. Преобразовать в формат для DPO (например, JSONL)
        // 3. Вызвать внешний скрипт Python (или использовать TorchSharp) для LoRA-дообучения
        // 4. Обновить веса модели (заменить .gguf или LoRA адаптер)
        // Здесь пока заглушка
        Console.WriteLine($"Fine-tuning запущен с {dataset.Count} примерами");
        await Task.CompletedTask;
    }
}