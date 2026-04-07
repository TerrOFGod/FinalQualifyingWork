using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Interactions.Quests
{
    public class QuestChain : IEntity
    {
        public int Id => ChainQuestId;
        public int ChainQuestId { get; set; }
    }
}
