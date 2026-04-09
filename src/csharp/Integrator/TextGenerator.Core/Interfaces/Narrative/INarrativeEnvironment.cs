using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Actors;

namespace TextGenerator.Core.Interfaces.Narrative;

/// <summary>
/// Предоставляет актуальный контекст игрового мира (локация, события, состояния, отношения).
/// </summary>
public interface INarrativeEnvironment
{
    /// <summary>Получить релевантный контекст для текущего ввода игрока.</summary>
    Task<WorldContext> GetRelevantContext(SmartNPC npc, Player player, string currentInput);
    
    /// <summary>Обновить состояние сущности в мире.</summary>
    Task UpdateState(string entityId, string property, object value);
    
    /// <summary>Получить социальные связи NPC.</summary>
    Task<IEnumerable<SocialConnection>> GetRelationships(int npcId);
    
    /// <summary>Записать событие взаимодействия в лог мира.</summary>
    Task LogInteraction(string description, DateTime timestamp);
}