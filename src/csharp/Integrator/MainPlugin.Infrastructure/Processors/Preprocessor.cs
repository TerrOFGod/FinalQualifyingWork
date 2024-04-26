﻿using GPTTextGenerator.Entities.Interfaces.Processors;
using GPTTextGenerator.Entities.Models.Interactors;
using System.Linq;
using static IronPython.Modules.PythonIterTools;

namespace GPTTextGenerator.Infrastructure.Processors
{
    public class Preprocessor : IPreprocessor
    {
        public string GenerateBasicBranchedDialogueRequest(SmartNPC npc, int depth, int variety)
        {
            string entry = GenerateEntryString(npc);
            string characteristics = $"Личностные качества: {string.Join(", ", npc.PersonalCharacteristics)}";
            string society = "Социальные связи: " + string.Join(", ", 
                npc.SocialConnections.Select(con => $"{con.RelatedNPC.Name} (тип связи - {con.Type})"));
            string behavior = $"Поведение: {string.Join(", ", npc.Behaviors)}";
            string branchesLimitation = GenerateBranchesLimitationString(npc, depth, variety);
            List<string> list = new List<string>();
            //list.Add("0");
            for (int i = 0; i < depth; i++)
            {
                list.Add(variety.ToString());
            }
            string endBranch = string.Join('.', list);

            return $"{entry}. {characteristics}. {society}. {behavior}. {branchesLimitation} Оформи в виде нумерованного цифрового списка. Формат списка regex: @\"(?<variant>\\d+(?:\\.\\d+)*)\\s+(?<playerName>\\w+)\\s*:\\s*\"\"(?<playerPhrase>[^\"\"]+)\"\"\\s+(?<npcName>\\w+)\\s*:\\s*\"\"(?<npcPhrase>[^\"\"]+)\"\"\". Конечное значение {endBranch} . Варианты игрока первого уровня имеют формат цифры и находятся на уровне вступительной фразы, то есть вступление 0 варианты игрока: 1, 2, .....";
        }

        private string GenerateBranchesLimitationString(SmartNPC npc, int depth, int variety)
        {
            List<string> cond = new();
            string entry = $"Предложи вступление от NPC '{npc.Name}' как 0 уровень.";
            cond.Add(entry);
            for (int i = 0; i < depth; i++)
            {
                string level = 
                    $"На {i + 1} уровне предоставьте по {variety} варианта ответа игрока{(i + 1 == 1 ? "" : " на каждый из предыдущих вариантов игрока")}, при этом NPC '{npc.Name}' должен отвечать на каждую фразу игрока{(i + 1 == depth ? "" : ".")}";
                cond.Add(level);
            }
            return $"{string.Join(' ', cond)}, обеспечивая все { Math.Pow(variety, depth)} возможных ветвей развития диалога.";
        }

        private string GenerateEntryString(SmartNPC npc)
        {
            return $"Создай ветвистый диалог с NPC по имени '{npc.Name}', тип '{npc.Type}', возраст {npc.Age} лет, внешность - {npc.Appearance}, профессия - {npc.Profession}";
        }

    }
}