namespace TextGenerator.Core.Models.Metrics;

public class PersonalizationMetrics
{
    public float PersonalizationCoefficient { get; set; } // P
    public float DynamicAdaptationCoefficient { get; set; } // D
}

public static class MetricsCalculator
{
    public static float ComputeP(Dictionary<string, float> relevances, Dictionary<string, float> weights)
    {
        float sum = 0;
        foreach (var kv in relevances)
            if (weights.ContainsKey(kv.Key)) sum += kv.Value * weights[kv.Key];
        return sum / weights.Values.Sum();
    }
    
    public static float ComputeD(float actualComplexity, float expectedComplexity, float maxComplexity)
    {
        return 1 - (Math.Abs(actualComplexity - expectedComplexity) / maxComplexity);
    }
}