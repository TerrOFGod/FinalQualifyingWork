using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;

namespace TextGenerator.Core.Models.World
{
    public class GameObject : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public IEnumerable<Stat>? Stats { get; set; }
        public ItemType GameObjectType { get; set; }
        public string History { get; set; }
    }
}
