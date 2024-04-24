using MainPlugin.Core.Entities.Enums;
using MainPlugin.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Models.Misc
{
    public class PObject : IBase
    {
        public int Id => PObjectId;
        public int PObjectId { get; set; }
        public IEnumerable<Stat>? Stats { get; set; }
        public ItemType PObjectType { get; set; }
        public string History { get; set; }
    }
}
