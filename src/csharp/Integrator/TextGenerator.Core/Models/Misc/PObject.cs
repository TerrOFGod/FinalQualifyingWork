using System.Collections.Generic;
using TextGenerator.Core.Enums;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Misc
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
