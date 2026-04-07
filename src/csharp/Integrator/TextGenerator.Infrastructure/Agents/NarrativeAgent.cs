using TextGenerator.Core.Interfaces.Memorize;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;
using TextGenerator.Infrastructure.EdgeAI;
using TextGenerator.Infrastructure.Memory;
using TextGenerator.Infrastructure.Processors;
using TextGenerator.Infrastructure.RAG;
using TextGenerator.Infrastructure.Reward;

namespace TextGenerator.Infrastructure.Agents;

    public class NarrativeAgent : INarrativeAgent
    {
        private readonly LocalLLMClient _llm;
        private readonly Preprocessor _preprocessor;
        private readonly Postprocessor _postprocessor;
        private readonly RAGService _rag;
        private readonly RewardCalculator _reward;
        private readonly Summarizer _summarizer;

        public NarrativeAgent(LocalLLMClient llm, Preprocessor preprocessor, Postprocessor postprocessor,
                              RAGService rag, RewardCalculator reward, Summarizer summarizer)
        {
            _llm = llm;
            _preprocessor = preprocessor;
            _postprocessor = postprocessor;
            _rag = rag;
            _reward = reward;
            _summarizer = summarizer;
        }

        public async Task<DialogueEntry> GenerateDialogue(SmartNPC npc, Player player, string playerInput, int depth, int variety)
        {
            // 1. Получить релевантные воспоминания из RAG
            var augmentedPrompt = await _rag.AugmentPrompt(playerInput,
                _preprocessor.GenerateBasicBranchedDialogueRequest(npc, depth, variety));

            // 2. Сгенерировать диалог через локальную LLM
            string rawResponse = await _llm.GenerateAsync(augmentedPrompt, maxTokens: 1024);

            // 3. Постобработка
            DialogueEntry dialogue = _postprocessor.DecodeAPIBranchedDialogueResponse(npc, rawResponse);

            // 4. Оценка качества и сохранение награды
            float reward = _reward.CalculateReward(rawResponse, playerInput, npc.PersonalCharacteristics[0]);
            // можно сохранить reward для дальнейшего fine-tuning

            // 5. Сохранить взаимодействие в памяти
            await _rag.StoreInteraction($"Игрок: {playerInput} -> NPC: {dialogue.Text}", $"NPC={npc.Name}");

            return dialogue;
        }

        public async Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription)
        {
            var prompt = _preprocessor.GenerateQuestPrompt(npc, player, goalDescription); // новый метод в Preprocessor
            var rawQuest = await _llm.GenerateAsync(prompt);
            var quest = _postprocessor.ParseQuest(rawQuest);
            await _rag.StoreInteraction($"Сгенерирован квест: {quest.Name}", $"NPC={npc.Name}");
            return quest;
        }
    }