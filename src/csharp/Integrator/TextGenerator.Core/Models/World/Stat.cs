using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;

namespace TextGenerator.Core.Models.World
{
    public class Stat : IEntity
    {
        public int Id => StatId;
        public int StatId { get; set; }
        public StatType StatType { get; set; }
        public float Value { get; set; }
    }
}
