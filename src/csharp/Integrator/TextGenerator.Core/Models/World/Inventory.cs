using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.World
{
    public class Inventory : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public int OwnerID { get; set; } // Ссылка на владельца инвентаря
        public List<Item> Items { get; set; }
    }
}
