using System.Numerics;
using TextGenerator.Core.Common;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.World;

namespace TextGenerator.Core.Models.Actors
{
    public class Player : IEntity
    {
        public int Id => ID;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Vector3 Position { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public Inventory Inventory { get; set; }
        public List<DialogueEntry> Dialogues { get; set; }
        public List<GameReaction> Reactions { get; set; }
        public List<GameAction> Actions { get; set; }
    }
}
