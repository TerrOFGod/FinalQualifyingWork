using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Interactions.Quests
{
    public class Requirement : IEntity
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
