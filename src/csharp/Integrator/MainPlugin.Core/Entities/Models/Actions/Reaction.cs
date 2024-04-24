using MainPlugin.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Models.Actions
{
    public class Reaction : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
