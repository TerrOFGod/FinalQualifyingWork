using Microsoft.Extensions.Caching.Memory;
using Neo4j.Driver;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Actors;

namespace TextGenerator.Infrastructure.Narrative.Environment;

public class NarrativeEnvironmentService : INarrativeEnvironment
{
    private readonly IDriver _neo4jDriver;
    private readonly IMemoryCache _cache;

    public async Task<WorldContext> GetRelevantContext(SmartNPC npc, Player player, string currentInput)
    {
        // 1. Получить местоположение, время суток
        // 2. Получить последние 5 событий из истории
        // 3. Получить связи NPC с другими персонажами
        // 4. Вернуть структурированный объект
        var context = new WorldContext();
        // ... реализация через Cypher-запросы
        return new WorldContext
        {
            LocationDescription = "Unknown location",
            RecentEvents = new List<string>(),
            EntityStates = new Dictionary<string, string>(),
            TimeOfDay = 12.0f
        };
    }

    public Task UpdateState(string entityId, string property, object value)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SocialConnection>> GetRelationships(int npcId)
    {
        throw new NotImplementedException();
    }

    public Task LogInteraction(string description, DateTime timestamp)
    {
        throw new NotImplementedException();
    }
}