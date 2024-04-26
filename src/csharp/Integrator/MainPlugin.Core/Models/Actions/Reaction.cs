using GPTTextGenerator.Entities.Interfaces;

namespace GPTTextGenerator.Entities.Models.Actions
{
    public class Reaction : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
