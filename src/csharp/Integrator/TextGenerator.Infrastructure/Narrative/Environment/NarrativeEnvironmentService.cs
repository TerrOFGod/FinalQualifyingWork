using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using Neo4j.Driver;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Actors;

namespace TextGenerator.Infrastructure.Narrative.Environment;

/// <summary>
/// Реализация получения контекста мира из Neo4j и кэша.
/// </summary>
public class NarrativeEnvironmentService : INarrativeEnvironment
{
    private readonly IDriver _neo4jDriver;
    private readonly IMemoryCache _cache;
    private readonly ConcurrentDictionary<string, byte> _cacheKeys = new();
    private const string CacheKeyPrefix = "narrative_env_";

    public NarrativeEnvironmentService(IDriver neo4jDriver, IMemoryCache memoryCache)
    {
        _neo4jDriver = neo4jDriver;
        _cache = memoryCache;
    }

    public Task<WorldContext> GetRelevantContext(SmartNPC npc, Player player, string currentInput)
    {
        // string cacheKey = $"{CacheKeyPrefix}{npc.Id}_{player.Id}";
        // if (_cache.TryGetValue(cacheKey, out WorldContext cachedContext))
        //     return cachedContext;
        //
        // var context = new WorldContext();
        // await using var session = _neo4jDriver.AsyncSession();
        //
        // // 1. Местоположение и время суток
        // var locationResult = await session.RunAsync(
        //     @"MATCH (n:NPC {id: $npcId})-[:LOCATED_AT]->(loc:Location)
        //       RETURN loc.description AS location, loc.timeOfDay AS timeOfDay",
        //     new { npcId = npc.Id });
        // var locationRecord = await locationResult.SingleAsync();
        // context.LocationDescription = locationRecord["location"].As<string>();
        // context.TimeOfDay = locationRecord["timeOfDay"].As<float>();
        //
        // // 2. Последние 5 событий из истории взаимодействий
        // var eventsResult = await session.RunAsync(
        //     @"MATCH (n:NPC {id: $npcId})-[r:INTERACTED_WITH]->(p:Player {id: $playerId})
        //       RETURN r.description AS event
        //       ORDER BY r.timestamp DESC LIMIT 5",
        //     new { npcId = npc.Id, playerId = player.Id });
        // var events = await eventsResult.ToListAsync();
        // context.RecentEvents = events.Select(r => r["event"].As<string>()).ToList();
        //
        // // 3. Состояния сущностей (например, двери открыта/закрыта)
        // var statesResult = await session.RunAsync(
        //     @"MATCH (e:Entity)
        //       WHERE e.id STARTS WITH 'world_'
        //       RETURN e.id AS entityId, e.state AS state");
        // var states = await statesResult.ToListAsync();
        // context.EntityStates = states.ToDictionary(
        //     s => s["entityId"].As<string>(),
        //     s => s["state"].As<string>());
        //
        // // Make sure to add the key to tracker after setting cache:
        // var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
        // _cache.Set(cacheKey, context, cacheEntryOptions);
        // _cacheKeys.TryAdd(cacheKey, 0);
        // return context;
        
        return Task.FromResult(new WorldContext
        {
            LocationDescription = "A dark forest clearing",
            RecentEvents = new List<string> { "You hear wolves howling in the distance." },
            EntityStates = new Dictionary<string, string> { { "gate", "closed" } },
            TimeOfDay = 0.75f // вечер
        });
    }

    public Task UpdateState(string entityId, string property, object value)
    {
        // await using var session = _neo4jDriver.AsyncSession();
        // await session.RunAsync(
        //     @"MATCH (e:Entity {id: $entityId})
        //       SET e.$property = $value",
        //     new { entityId, property, value });
        // // Инвалидируем кэш, связанный с этой сущностью
        // var keysToRemove = _cacheKeys.Keys.Where(k => k.Contains(entityId)).ToList();
        // foreach (var key in keysToRemove)
        // {
        //     _cache.Remove(key);
        //     _cacheKeys.TryRemove(key, out _);
        // }

        return Task.FromResult(Task.CompletedTask);
    }

    public Task<IEnumerable<SocialConnection>> GetRelationships(int npcId)
    {
        // await using var session = _neo4jDriver.AsyncSession();
        // var result = await session.RunAsync(
        //     @"MATCH (n:NPC {id: $npcId})-[r:RELATED_TO]->(other:NPC)
        //       RETURN other.id AS relatedId, other.name AS relatedName, type(r) AS relationType, r.description AS relationshipDesc",
        //     new { npcId });
        // var records = await result.ToListAsync();
        // var connections = new List<SocialConnection>();
        // foreach (var record in records)
        // {
        //     connections.Add(new SocialConnection
        //     {
        //         ID = 0, // ID не хранится в графе, можно сгенерировать
        //         RelatedNPC = new SmartNPC { ID = record["relatedId"].As<int>(), Name = record["relatedName"].As<string>() },
        //         Type = record["relationType"].As<string>(),
        //         Relationships = record["relationshipDesc"].As<string>()
        //     });
        // }
        // return connections;
        return Task.FromResult(Enumerable.Empty<SocialConnection>());
    }

    public Task LogInteraction(string description, DateTime timestamp)
    {
        // await using var session = _neo4jDriver.AsyncSession();
        // await session.RunAsync(
        //     @"CREATE (e:Event {description: $description, timestamp: $timestamp})",
        //     new { description, timestamp });
        return Task.FromResult(Task.CompletedTask);
    }
}