using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Interactions.Dialogues
{
    public class DialogueNode : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string InterlocutorNPC { get; set; }
        public string InterlocutorPlayer { get; set; }
        public string Name { get; set; }
        public string NPCText { get; set; }
        public string PlayerText { get; set; }
        public List<DialogueNode> Childs { get; set; }
        
        public void AddChild(DialogueNode child)
        {
            Childs ??= new List<DialogueNode>();
            if (!Childs.Contains(child))
                Childs.Add(child);
        }
    }
}
