using GPTTextGenerator.Entities.Models.Objects;
using GPTTextGenerator.Entities.Interfaces;
using GPTTextGenerator.Entities.Models.Actions;
using GPTTextGenerator.Entities.Models.Interactions;
using System.Numerics;
using Action = GPTTextGenerator.Entities.Models.Actions.Action;
using System.Collections.Generic;

namespace GPTTextGenerator.Entities.Models.Interactors
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
