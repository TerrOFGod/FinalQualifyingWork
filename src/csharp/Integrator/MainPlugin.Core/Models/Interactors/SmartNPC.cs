using GPTTextGenerator.Entities.Interfaces;
using GPTTextGenerator.Entities.Models.Actions;
using GPTTextGenerator.Entities.Models.Interactions;
using Action = GPTTextGenerator.Entities.Models.Actions.Action;

namespace GPTTextGenerator.Entities.Models.Interactors
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
