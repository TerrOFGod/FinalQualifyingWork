namespace TextGenerator.Core.Interfaces.RAG;

public interface IRAGService
{
    Task<string> AugmentPrompt(string userQuery, string basePrompt);
    Task StoreInteraction(string text, string metadata);
}