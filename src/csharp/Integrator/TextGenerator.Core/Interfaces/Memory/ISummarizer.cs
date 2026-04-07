namespace TextGenerator.Core.Interfaces.Memory;

public interface ISummarizer
{
    Task<string> Summarize(string longText);
}