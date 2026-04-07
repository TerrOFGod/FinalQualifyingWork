using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Interfaces.Cache;

public interface IDialogueCache
{
    bool TryGet(string key, out DialogueEntry entry);
    void Set(string key, DialogueEntry entry, TimeSpan? ttl = null);
    string MakeKey(SmartNPC npc, Player player, string playerInput, string contextHash);
}