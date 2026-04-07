using TextGenerator.Core.Enums;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Objects
{
    public class Item : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
    }
}
