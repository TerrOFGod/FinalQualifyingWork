namespace TextGenerator.Core.Interfaces.EdgeAI;

public interface ILLMClient
{
    Task<string> GenerateAsync(string prompt, int maxTokens = 256, float temperature = 0.7f);
}