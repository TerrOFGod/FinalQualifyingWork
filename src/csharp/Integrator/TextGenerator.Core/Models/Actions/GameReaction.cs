using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Actions
{
    public class GameReaction : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
