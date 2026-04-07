using TextGenerator.Core.Common;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Models.Actors
{
    public class SmartNPC : IEntity
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
        public List<GameReaction> Reactions { get; set; }
        public List<GameAction> Actions { get; set; }
    }
}
