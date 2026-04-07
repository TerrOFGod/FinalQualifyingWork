namespace TextGenerator.Core.Interfaces.Memory;

public interface IRewardCalculator
{
    float CalculateReward(string generatedText, string context, string expectedStyle);
}