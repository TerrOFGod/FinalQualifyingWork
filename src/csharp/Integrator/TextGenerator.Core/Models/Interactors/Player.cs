using System.Numerics;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Objects;
using Action = TextGenerator.Core.Models.Actions.Action;

namespace TextGenerator.Core.Models.Interactors
{
    public class Player : IBase
    {
        public int Id => ID;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Vector3 Position { get; set; }
        public int Health { get; set; }
        public Inventory Inventory { get; set; }
        public List<DialogueEntry> Dialogues { get; set; }
        public List<Reaction> Reactions { get; set; }
        public List<Action> Actions { get; set; }
    }
}
