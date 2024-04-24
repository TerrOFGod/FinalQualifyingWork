using MainPlugin.Core.Entities.Interfaces;
using MainPlugin.Core.Entities.Models.Actions;
using MainPlugin.Core.Entities.Models.Interactions;
using MainPlugin.Core.Entities.Models.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Action = MainPlugin.Core.Entities.Models.Actions.Action;

namespace MainPlugin.Core.Entities.Models.Interactors
{
    public class SmartNPC : IBase
    {
        public int Id => ID;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // Герой, злодей и т.д.
        public int Age { get; set; } //возраст
        public string Appearance { get; set; } // Простое описание по типу внешности
        public string Profession { get; set; }
        public List<string> PersonalCharacteristics { get; set; } // список личностных качеств
        public List<SocialConnection> SocialConnections { get; set; } // Связаннае NPC, тип их связи(муж, работник и т.д.), взаимоотношения
        public List<string> Behaviors { get; set; } // Это может включать типы поведения NPC, например, "агрессивное", "пассивное", "нейтральное", и т.д.
        public List<DialogueEntry> Dialogues { get; set; }
        public List<Reaction> Reactions { get; set; }
        public List<Action> Actions { get; set; }
    }
}
