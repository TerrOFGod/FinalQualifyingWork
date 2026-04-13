using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;

namespace TextGenerator.Core.Models.World
{
    public class Stat : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public StatType StatType { get; set; }
        public float Value { get; set; }
    }
}
