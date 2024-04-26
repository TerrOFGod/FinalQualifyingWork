using GPTTextGenerator.Entities.Models.Interactors;
using GPTTextGenerator.Entities.Models.Misc;
using GPTTextGenerator.Entities.Interfaces;

namespace GPTTextGenerator.Entities.Models.Interactors
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
