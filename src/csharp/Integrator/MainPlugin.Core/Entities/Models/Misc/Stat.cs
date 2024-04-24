using MainPlugin.Core.Entities.Enums;
using MainPlugin.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Models.Misc
{
    public class Stat : IBase
    {
        public int Id => throw new NotImplementedException();
        public int StatId { get; set; }
        public StatType StatType { get; set; }
        public float Value { get; set; }
    }
}
