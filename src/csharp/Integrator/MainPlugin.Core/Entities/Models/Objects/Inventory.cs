using MainPlugin.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Models.Objects
{
    public class Inventory : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public int OwnerID { get; set; } // Ссылка на владельца инвентаря
        public List<Item> Items { get; set; }
    }
}
