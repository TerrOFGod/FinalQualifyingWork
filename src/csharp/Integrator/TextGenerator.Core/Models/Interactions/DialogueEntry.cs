using System.Collections.Generic;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Interactions
{
    public class DialogueEntry : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Text { get; set; }

        public List<DialogueNode> Childs { get; set; }
    }
}
