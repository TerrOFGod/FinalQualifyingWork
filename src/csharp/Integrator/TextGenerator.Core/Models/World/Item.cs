using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;

namespace TextGenerator.Core.Models.World
{
    public class Item : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
    }
}
