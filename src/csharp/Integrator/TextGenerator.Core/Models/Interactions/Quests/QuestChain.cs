using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Interactions.Quests
{
    public class QuestChain : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
