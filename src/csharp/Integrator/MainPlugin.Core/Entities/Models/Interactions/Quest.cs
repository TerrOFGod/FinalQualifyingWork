using MainPlugin.Core.Entities.Enums;
using MainPlugin.Core.Entities.Interfaces;
using MainPlugin.Core.Entities.Models.Actions;
using MainPlugin.Core.Entities.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Models.Interactions
{
    public class Quest : IBase
    {
        public int Id => ID;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Difficulty { get; set; }
        public List<Requirement> Requirements { get; set; }
        public List<Reward> Rewards { get; set; }
        public List<DialogueEntry> Dialogues { get; set; }
    }
}
