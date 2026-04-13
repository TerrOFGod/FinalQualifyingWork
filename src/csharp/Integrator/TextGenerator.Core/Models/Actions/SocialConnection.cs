using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Actors;

namespace TextGenerator.Core.Models.Actions
{
    public class SocialConnection : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public SmartNPC RelatedNPC { get; set; }

        public string Type { get; set; }
        public string Relationships { get; set; }
    }
}
