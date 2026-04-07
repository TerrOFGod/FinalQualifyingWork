using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;

namespace TextGenerator.Core.Models.World
{
    public class GameObject : IEntity
    {
        public int Id => PObjectId;
        public int PObjectId { get; set; }
        public IEnumerable<Stat>? Stats { get; set; }
        public ItemType PObjectType { get; set; }
        public string History { get; set; }
    }
}
