using MainPlugin.Core.Entities.Interfaces.Processors;
using MainPlugin.Core.Entities.Models.Interactors;
using System.Linq;

namespace MainPlugin.Infrastructure.Processors
{
    public class Preprocessor : IPreprocessor
    {
        public string GenerateBasicDialogueRequest(SmartNPC npc, int depth, int variety)
        {
            string entry = GenerateEntryString(npc);
            string characteristics = $"Личностные качества: {string.Join(", ", npc.PersonalCharacteristics)}";
            string society = "Социальные связи: " + string.Join(", ", 
                npc.SocialConnections.Select(con => $"{con.RelatedNPC.Name} (тип связи - {con.Type})"));
            string behavior = $"Поведение: {string.Join(", ", npc.Behaviors)}";
            string branchesLimitation = GenerateBranchesLimitationString(npc, depth, variety);
            return $"{entry}. {characteristics}. {society}. {behavior}. {branchesLimitation}";
        }

        private string GenerateBranchesLimitationString(SmartNPC npc, int depth, int variety)
        {
            List<string> cond = new();
            string entry = $"Предложи вступление от NPC '{npc.Name}' как 0 уровень.";
            cond.Add(entry);
            for (int i = 0; i < depth; i++)
            {
                string level = 
                    $"На {i + 1} уровне предоставьте по {variety} варианта ответа{(i + 1 == 1 ? "" : " на каждый из предыдущих вариантов игрока")}, при этом NPC '{npc.Name}' должен отвечать на каждую фразу игрока{(i + 1 == depth ? "" : ".")}";
                cond.Add(level);
            }
            return $"{string.Join(' ', cond)}, обеспечивая все { Math.Pow(variety, depth)} возможных ветвей развития диалога.";
        }

        private string GenerateEntryString(SmartNPC npc)
        {
            return $"Создай диалог с NPC по имени '{npc.Name}', тип '{npc.Type}', возраст {npc.Age} лет, внешность - {npc.Appearance}, профессия - {npc.Profession}";
        }

    }
}