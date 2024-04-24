using MainPlugin.Core.Entities.Interfaces;
using MainPlugin.Core.Entities.Models.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Models.Interactors
{
    public class Environment : IBase
    {
        public int Id => EnvironmentId;
        public int EnvironmentId { get; set; }
        public IEnumerable<SmartNPC> SmartNPCs { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<PObject> Objects { get; set; }
    }
}
