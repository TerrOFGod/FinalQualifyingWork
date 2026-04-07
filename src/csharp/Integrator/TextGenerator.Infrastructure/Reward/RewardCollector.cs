using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Models.Feedback;

namespace TextGenerator.Infrastructure.Reward;

public class RewardCollector : IRewardCollector
{
    private readonly List<InteractionFeedback> _feedbacks = new();
    private readonly object _lock = new();
    
    public void RecordFeedback(InteractionFeedback feedback)
    {
        lock (_lock) _feedbacks.Add(feedback);
    }

    public Task<List<InteractionFeedback>> GetDatasetAsync()
    {
        lock (_lock) return Task.FromResult(_feedbacks.ToList());
    }

    public async Task SaveToDatasetAsync(string path)
    {
        var json = JsonConvert.SerializeObject(_feedbacks, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);
    }
}