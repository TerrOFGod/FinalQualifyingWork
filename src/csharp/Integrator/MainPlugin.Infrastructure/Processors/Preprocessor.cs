using GPTTextGenerator.Entities.Interfaces.Processors;
using GPTTextGenerator.Entities.Models.Interactions;
using GPTTextGenerator.Entities.Models.Interactors;

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
            string endBranch = string.Join(".", list);

            return $"{entry}. {characteristics}. {society}. {behavior}. {branchesLimitation} Оформи в виде нумерованного цифрового списка. Формат списка regex: @\"(?<variant>\\d+(?:\\.\\d+)*)\\s+(?<playerName>\\w+)\\s*:\\s*\"\"(?<playerPhrase>[^\"\"]+)\"\"\\s+(?<npcName>\\w+)\\s*:\\s*\"\"(?<npcPhrase>[^\"\"]+)\"\"\". Конечное значение {endBranch} . Варианты игрока первого уровня имеют формат цифры и находятся на уровне вступительной фразы, то есть вступление 0 варианты игрока: 1, 2, .....";
        }

        public string GenerateBasicSteppedDialogueRequest(SmartNPC npc, DialogueNode prevNode, int variety)
        {
            
            string entry = $"Сгенерируй следующую ступень диалога для NPC {npc.Name}";
            string characteristics = $"Личностные качества: {string.Join(", ", npc.PersonalCharacteristics)}";
            string society = "Социальные связи: " + string.Join(", ",
                npc.SocialConnections.Select(con => $"{con.RelatedNPC.Name} (тип связи - {con.Type})"));
            string behavior = $"Поведение: {string.Join(", ", npc.Behaviors)}";
            string prevPlayerPhrase = $"Предыдущая фраза диалога игрока: {(prevNode != null ? prevNode.InterlocutorPlayer + ": " + prevNode.PlayerText : "")}\n";
            string prevNpcPhrase = $"Предыдущая фраза диалога NPC: {(prevNode != null ? npc.Name + ": " + prevNode.NPCText : "")}";
            string prevDialogueStep = $"{prevPlayerPhrase}{prevNpcPhrase}";
            List<string> list = new List<string>();
            //list.Add("0");
            for (int i = 0; i < variety; i++)
            {
                list.Add($"\n {i + 1}. Игрок: [Вариант {i + 1}] \n {npc.Name}: [Ответ на Вариант {i + 1}]");
            }

            string variantJoin = string.Join(" ", list);
            string formatter = $"Ответ должен быть в формате: {variantJoin}";
            string prompt = 
                $"{entry} (тип - {npc.Type}, возраст - {npc.Age} лет, внешность - {npc.Appearance}, профессия - {npc.Profession}). {characteristics}. {society}. {behavior}. {prevDialogueStep}. {formatter}";

            return prompt;
        }

        public string GenerateIntroductoryPhraseRequest(SmartNPC npc)
        {

            string entry = $"Сгенерируй вступительную фразу диалога для NPC {npc.Name}";
            string characteristics = $"Личностные качества: {string.Join(", ", npc.PersonalCharacteristics)}";
            string society = "Социальные связи: " + string.Join(", ",
                npc.SocialConnections.Select(con => $"{con.RelatedNPC.Name} (тип связи - {con.Type})"));
            string behavior = $"Поведение: {string.Join(", ", npc.Behaviors)}";
            string prompt = $"{entry} (тип - {npc.Type}, возраст - {npc.Age} лет, внешность - {npc.Appearance}, профессия - {npc.Profession}). {characteristics}. {society}. {behavior}.";

            return prompt;
        }

        private string GenerateBranchesLimitationString(SmartNPC npc, int depth, int variety)
        {
            List<string> cond = new List<string>();
            string entry = $"Предложи вступление от NPC '{npc.Name}' как 0 уровень.";
            cond.Add(entry);
            for (int i = 0; i < depth; i++)
            {
                string level = 
                    $"На {i + 1} уровне предоставьте по {variety} варианта ответа игрока{(i + 1 == 1 ? "" : " на каждый из предыдущих вариантов игрока")}, при этом NPC '{npc.Name}' должен отвечать на каждую фразу игрока{(i + 1 == depth ? "" : ".")}";
                cond.Add(level);
            }
            return $"{string.Join(" ", cond)}, обеспечивая все { Math.Pow(variety, depth)} возможных ветвей развития диалога.";
        }

        private string GenerateEntryString(SmartNPC npc)
        {
            return $"Создай ветвистый диалог с NPC по имени '{npc.Name}', тип '{npc.Type}', возраст {npc.Age} лет, внешность - {npc.Appearance}, профессия - {npc.Profession}";
        }

    }
}