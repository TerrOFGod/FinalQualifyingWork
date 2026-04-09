using Microsoft.Extensions.Caching.Memory;
using TextGenerator.Core.Interfaces.Cache;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Infrastructure.Caching;

/// <summary>
/// Реализация кэша диалогов на основе IMemoryCache.
/// </summary>
public class DialogueCache : IDialogueCache
{
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _defaultTtl = TimeSpan.FromMinutes(15);
    
    public DialogueCache(IMemoryCache cache) => _cache = cache;
    
    public bool TryGet(string key, out DialogueEntry entry) => _cache.TryGetValue(key, out entry);
    public void Set(string key, DialogueEntry entry, TimeSpan? ttl = null) 
        => _cache.Set(key, entry, ttl ?? _defaultTtl);
    
    public string MakeKey(SmartNPC npc, Player player, string playerInput, string contextHash)
        => $"dial_{npc.Id}_{player.Id}_{playerInput.GetHashCode()}_{contextHash}";
}