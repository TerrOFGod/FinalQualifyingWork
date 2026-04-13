using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.World
{
    public class Inventory : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public int OwnerID { get; set; } // Ссылка на владельца инвентаря
        public List<Item> Items { get; set; }
    }
}
