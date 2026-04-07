using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Interactions.Dialogues
{
    public class DialogueEntry : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Text { get; set; }

        public List<DialogueNode> Childs { get; set; }
    }
}
