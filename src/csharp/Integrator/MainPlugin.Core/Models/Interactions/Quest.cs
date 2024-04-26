using GPTTextGenerator.Entities.Models.Objects;
using GPTTextGenerator.Entities.Interfaces;
using GPTTextGenerator.Entities.Models.Actions;

namespace GPTTextGenerator.Entities.Models.Interactions
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
