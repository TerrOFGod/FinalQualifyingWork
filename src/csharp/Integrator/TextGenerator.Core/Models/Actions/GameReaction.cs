using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Actions
{
    public class GameReaction : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
