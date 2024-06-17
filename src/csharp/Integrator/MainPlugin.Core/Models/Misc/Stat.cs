using GPTTextGenerator.Entities.Enums;
using GPTTextGenerator.Entities.Interfaces;
using System;

namespace GPTTextGenerator.Entities.Models.Misc
{
    public class Stat : IBase
    {
        public int Id => StatId;
        public int StatId { get; set; }
        public StatType StatType { get; set; }
        public float Value { get; set; }
    }
}
