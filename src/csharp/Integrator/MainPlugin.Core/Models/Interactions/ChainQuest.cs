using GPTTextGenerator.Entities.Interfaces;

namespace GPTTextGenerator.Entities.Models.Interactions
{
    public class ChainQuest : IBase
    {
        public int Id => ChainQuestId;
        public int ChainQuestId { get; set; }
    }
}
