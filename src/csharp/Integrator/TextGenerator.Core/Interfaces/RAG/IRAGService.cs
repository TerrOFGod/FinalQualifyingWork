namespace TextGenerator.Core.Interfaces.RAG;

/// <summary>
/// Усиление промпта релевантными воспоминаниями из векторной памяти (RAG).
/// </summary>
public interface IRAGService
{
    /// <summary>Дополнить базовый промпт контекстом, извлечённым из памяти.</summary>
    Task<string> AugmentPrompt(string userQuery, string basePrompt);
    
    /// <summary>Сохранить взаимодействие в память для будущего использования.</summary>
    Task StoreInteraction(string text, string metadata);
}