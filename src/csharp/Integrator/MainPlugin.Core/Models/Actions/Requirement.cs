using GPTTextGenerator.Entities.Interfaces;
using System;

namespace GPTTextGenerator.Entities.Models.Actions
{
    public class Requirement : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
