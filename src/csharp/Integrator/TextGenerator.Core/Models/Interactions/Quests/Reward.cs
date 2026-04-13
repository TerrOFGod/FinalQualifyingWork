using TextGenerator.Core.Common;
using TextGenerator.Core.Models.World;

namespace TextGenerator.Core.Models.Interactions.Quests
{
    public class Reward : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public Item RelatedItem { get; set; }
    }
}
