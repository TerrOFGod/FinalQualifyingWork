using GPTTextGenerator.Entities.Enums;
using GPTTextGenerator.Entities.Interfaces;

namespace GPTTextGenerator.Entities.Models.Misc
{
    public class Stat : IBase
    {
        public int Id => throw new NotImplementedException();
        public int StatId { get; set; }
        public StatType StatType { get; set; }
        public float Value { get; set; }
    }
}
