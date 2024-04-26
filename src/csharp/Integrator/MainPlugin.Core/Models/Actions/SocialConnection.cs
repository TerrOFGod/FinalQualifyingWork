using GPTTextGenerator.Entities.Models.Interactors;
using GPTTextGenerator.Entities.Interfaces;

namespace GPTTextGenerator.Entities.Models.Actions
{
    public class SocialConnection : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public SmartNPC RelatedNPC { get; set; }

        public string Type { get; set; }
        public string Relationships { get; set; }
    }
}
