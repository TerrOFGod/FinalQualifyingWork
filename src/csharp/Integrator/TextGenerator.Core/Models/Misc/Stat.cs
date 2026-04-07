using System;
using TextGenerator.Core.Enums;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Misc
{
    public class Stat : IBase
    {
        public int Id => StatId;
        public int StatId { get; set; }
        public StatType StatType { get; set; }
        public float Value { get; set; }
    }
}
