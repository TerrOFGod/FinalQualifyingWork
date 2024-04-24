using MainPlugin.Core.Entities.Interfaces;
using MainPlugin.Core.Entities.Models.Actions;
using MainPlugin.Core.Entities.Models.Interactions;
using MainPlugin.Core.Entities.Models.Misc;
using MainPlugin.Core.Entities.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Action = MainPlugin.Core.Entities.Models.Actions.Action;

namespace MainPlugin.Core.Entities.Models.Interactors
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
