namespace TextGenerator.Core.Interfaces.Memorize;

public interface IRewardSystem
{
    float CalculateReward(string generatedText, string context, string expectedStyle);
}