using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Interactions
{
    public class ChainQuest : IBase
    {
        public int Id => ChainQuestId;
        public int ChainQuestId { get; set; }
    }
}
