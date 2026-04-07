using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Interactions.Dialogues
{
    public class DialogueNode : IEntity
    {
        public int Id => ID;
        public int ID { get; set; }
        public string InterlocutorNPC { get; set; }
        public string InterlocutorPlayer { get; set; }
        public string Name { get; set; }
        public string NPCText { get; set; }
        public string PlayerText { get; set; }
        public List<DialogueNode> Childs { get; set; }
    }
}
