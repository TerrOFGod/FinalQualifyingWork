using System.Collections.Generic;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Objects;

namespace TextGenerator.Core.Models.Interactions
{
    public class Quest : IBase
    {
        public int Id => ID;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Difficulty { get; set; }
        public List<Requirement> Requirements { get; set; }
        public List<Reward> Rewards { get; set; }
        public List<DialogueEntry> Dialogues { get; set; }
    }
}
