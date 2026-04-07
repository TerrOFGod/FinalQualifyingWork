using TextGenerator.Core.Models.Feedback;

namespace TextGenerator.Core.Interfaces.Memory;

public interface IRewardCollector
{
    void RecordFeedback(InteractionFeedback feedback);
    Task<List<InteractionFeedback>> GetDatasetAsync();
    Task SaveToDatasetAsync(string path);
}