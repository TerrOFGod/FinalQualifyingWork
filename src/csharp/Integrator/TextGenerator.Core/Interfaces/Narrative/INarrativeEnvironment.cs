using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Actors;

namespace TextGenerator.Core.Interfaces.Narrative;

public interface INarrativeEnvironment
{
    Task<WorldContext> GetRelevantContext(SmartNPC npc, Player player, string currentInput);
    Task UpdateState(string entityId, string property, object value);
    Task<IEnumerable<SocialConnection>> GetRelationships(int npcId);
    Task LogInteraction(string description, DateTime timestamp);
}