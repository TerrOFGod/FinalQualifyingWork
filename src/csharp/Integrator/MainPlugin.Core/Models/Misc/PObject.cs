using GPTTextGenerator.Entities.Enums;
using GPTTextGenerator.Entities.Interfaces;

namespace GPTTextGenerator.Entities.Models.Misc
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
