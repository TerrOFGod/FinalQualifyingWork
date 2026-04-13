using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Interfaces.Cache;

/// <summary>
/// Кэш для ответов диалогов, сгенерированных LLM.
/// </summary>
public interface IDialogueCache
{
    /// <summary>Попытаться получить запись из кэша по ключу.</summary>
    bool TryGet(string key, out DialogueNode entry);
    
    /// <summary>Сохранить запись в кэше с опциональным временем жизни.</summary>
    void Set(string key, DialogueNode entry, TimeSpan? ttl = null);
    
    /// <summary>Сформировать уникальный ключ для кэширования диалога.</summary>
    string MakeKey(SmartNPC npc, Player player, string playerInput, string contextHash);
}