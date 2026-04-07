namespace TextGenerator.Core.Interfaces.RL;

public interface IRLFineTuner
{
    Task RunPeriodicFineTuningAsync();
}