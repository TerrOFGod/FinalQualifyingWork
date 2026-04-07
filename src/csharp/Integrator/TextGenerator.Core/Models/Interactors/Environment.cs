using TextGenerator.Core.Models.Interactors;
using System.Collections.Generic;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Misc;

namespace TextGenerator.Core.Models.Interactors
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
