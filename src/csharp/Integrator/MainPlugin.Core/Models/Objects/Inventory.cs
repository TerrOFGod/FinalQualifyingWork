using GPTTextGenerator.Entities.Interfaces;
using System.Collections.Generic;

namespace GPTTextGenerator.Entities.Models.Objects
{
    public class Inventory : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public int OwnerID { get; set; } // Ссылка на владельца инвентаря
        public List<Item> Items { get; set; }
    }
}
