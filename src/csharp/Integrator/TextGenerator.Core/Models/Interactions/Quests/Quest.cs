using TextGenerator.Core.Common;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Models.Interactions.Quests
{
    public class Quest : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Difficulty { get; set; }
        public List<Requirement> Requirements { get; set; }
        public List<Reward> Rewards { get; set; }
        public List<DialogueNode> Dialogues { get; set; }
    }
}
