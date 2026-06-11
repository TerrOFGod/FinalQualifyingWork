# Project Structure

```
TextGenerator.Core/
  bin/
  Common/
    Enums/
      ItemType.cs
      StatType.cs
      Status.cs
    IEntity.cs
  Interfaces/
    Cache/
      IDialogueCache.cs
    EdgeAI/
      ILLMClient.cs
    Memory/
      IEmbeddingGenerator.cs
      IFeedbackCollector.cs
      IRewardCalculator.cs
      ITextSummarizer.cs
      IVectorMemoryStore.cs
    Narrative/
      INarrativeAgent.cs
      INarrativeEnvironment.cs
    Processors/
      IDialogueValidator.cs
      ILLMPromptBuilder.cs
      ILLMResponseParser.cs
      IPostprocessor.cs
      IPreprocessor.cs
    RAG/
      IRAGService.cs
    RL/
      IModelFineTuner.cs
  Models/
    Actions/
      GameAction.cs
      GameReaction.cs
      SocialConnection.cs
    Actors/
      Player.cs
      SmartNPC.cs
      WorldContext.cs
    Feedback/
      InteractionFeedback.cs
    Interactions/
      Dialogues/
        DialogueNode.cs
      Quests/
        Quest.cs
        QuestChain.cs
        Requirement.cs
        Reward.cs
    Metrics/
      PersonalizationMetrics.cs
    World/
      GameObject.cs
      Inventory.cs
      Item.cs
      Stat.cs
  obj/
  TextGenerator.Core.csproj
TextGenerator.Infrastructure/
  bin/
  Caching/
    DialogueCache.cs
  EdgeAI/
    LLamaSharpOptions.cs
    LocalLLMClient.cs
    ModelDownloader.cs
  Extensions/
    DialogueExtensions.cs
  Memory/
    EmbeddingGeneratorService.cs
    QdrantVectorMemoryStore.cs
    TextSummarizer.cs
  Narrative/
    Agents/
      NarrativeAgent.cs
    Environment/
      NarrativeEnvironmentService.cs
  obj/
  Processors/
    DialogueValidator.cs
    LLMPromptBuilder.cs
    LLMResponseParser.cs
    PostprocessorService.cs
    PreprocessorService.cs
  RAG/
    RAGService.cs
  Reward/
    FeedbackCollector.cs
    RewardCalculator.cs
  RL/
    ModelFineTuner.cs
  TextGenerator.Infrastructure.csproj
TextGenerator.Service/
  bin/
  Controllers/
    DialogueController.cs
    QuestController.cs
  model/
  obj/
  Properties/
  GPTTextGenerator.Service.http
  Program.cs
  TextGenerator.Service.csproj
```


## TextGenerator.Core\Common\Enums\ItemType.cs

```cs
namespace TextGenerator.Core.Common.Enums
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable,
        QuestItem,
        Resource
    }
}
```


## TextGenerator.Core\Common\Enums\StatType.cs

```cs
namespace TextGenerator.Core.Common.Enums
{
    public enum StatType
    {
        Damage,
        Int,
        Wis,
        End,
        Dex,
        Mem,
        Str,
        PhysRes,
        MagRes,

    }
}
```


## TextGenerator.Core\Common\Enums\Status.cs

```cs
namespace TextGenerator.Core.Common.Enums
{
    public enum Status
    {
        Running,
        Completed,
        NotStarted,
        NotEnoughEntryCondition
    }
}
```


## TextGenerator.Core\Common\IEntity.cs

```cs
namespace TextGenerator.Core.Common
{
    /// <summary>
    /// Базовый интерфейс для всех сущностей, имеющих уникальный идентификатор.
    /// </summary>
    public interface IEntity
    {
        /// <summary>Уникальный идентификатор сущности.</summary>
        public Guid Id { get; }
    }
}
```


## TextGenerator.Core\Interfaces\Cache\IDialogueCache.cs

```cs
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Interfaces.Cache;

/// <summary>
/// Кэш для ответов диалогов, сгенерированных LLM.
/// </summary>
public interface IDialogueCache
{
    /// <summary>Попытаться получить запись из кэша по ключу.</summary>
    bool TryGet(string key, out DialogueNode entry);
    
    /// <summary>Сохранить запись в кэше с опциональным временем жизни.</summary>
    void Set(string key, DialogueNode entry, TimeSpan? ttl = null);
    
    /// <summary>Сформировать уникальный ключ для кэширования диалога.</summary>
    string MakeKey(SmartNPC npc, Player player, string playerInput, string contextHash);
}
```


## TextGenerator.Core\Interfaces\EdgeAI\ILLMClient.cs

```cs
namespace TextGenerator.Core.Interfaces.EdgeAI;

/// <summary>
/// Клиент для взаимодействия с локальной языковой моделью (LLM).
/// </summary>
public interface ILLMClient
{
    /// <summary>Асинхронная генерация текста на основе промпта.</summary>
    /// <param name="prompt">Входной промпт.</param>
    /// <param name="maxTokens">Максимальное количество токенов в ответе.</param>
    /// <param name="temperature">Температура (случайность) генерации.</param>
    Task<string> GenerateAsync(string prompt, int maxTokens = 256, float temperature = 0.7f);
    
    /// <summary>Генерация с заданием системной роли (для изолированного чат-сеанса).</summary>
    Task<string> GenerateWithSystemAsync(string prompt, string systemPrompt, int? variety, int maxTokens = 256,
        float temperature = 0.7f);
}
```


## TextGenerator.Core\Interfaces\Memory\IEmbeddingGenerator.cs

```cs
namespace TextGenerator.Core.Interfaces.Memory;

/// <summary>
/// Генератор векторных представлений (эмбеддингов) для текста.
/// </summary>
public interface IEmbeddingGenerator
{
    /// <summary>Получить эмбеддинг для заданного текста.</summary>
    float[] GetEmbedding(string text);
}
```


## TextGenerator.Core\Interfaces\Memory\IFeedbackCollector.cs

```cs
using TextGenerator.Core.Models.Feedback;

namespace TextGenerator.Core.Interfaces.Memory;

/// <summary>
/// Сбор и сохранение обратной связи от игрока/системы для последующего дообучения.
/// </summary>
public interface IFeedbackCollector
{
    /// <summary>Записать один эпизод обратной связи.</summary>
    void RecordFeedback(InteractionFeedback feedback);
    
    /// <summary>Получить весь накопленный датасет.</summary>
    Task<List<InteractionFeedback>> GetDatasetAsync();
    
    /// <summary>Сохранить датасет в JSON-файл.</summary>
    Task SaveToDatasetAsync(string path);
}
```


## TextGenerator.Core\Interfaces\Memory\IRewardCalculator.cs

```cs
namespace TextGenerator.Core.Interfaces.Memory;

/// <summary>
/// Оценка качества сгенерированной реплики диалога (награда для RL).
/// </summary>
public interface IRewardCalculator
{
    /// <summary>Вычислить награду на основе сгенерированного текста, контекста и ожидаемого стиля.</summary>
    float CalculateReward(string generatedText, string context, string expectedStyle);
}
```


## TextGenerator.Core\Interfaces\Memory\ITextSummarizer.cs

```cs
namespace TextGenerator.Core.Interfaces.Memory;

/// <summary>
/// Сервис для суммаризации длинных текстов с помощью LLM.
/// </summary>
public interface ITextSummarizer
{
    /// <summary>Создать краткий пересказ текста (не более 2-3 предложений).</summary>
    Task<string> Summarize(string longText);
}
```


## TextGenerator.Core\Interfaces\Memory\IVectorMemoryStore.cs

```cs
namespace TextGenerator.Core.Interfaces.Memory;

/// <summary>
/// Хранилище векторной памяти (например, Qdrant) с возможностью поиска по сходству.
/// </summary>
public interface IVectorMemoryStore
{
    /// <summary>Добавить текст с его эмбеддингом и метаданными.</summary>
    Task AddMemory(string text, float[] embedding, string metadata);
    
    /// <summary>Найти topK наиболее релевантных записей.</summary>
    Task<List<(string Text, float Score)>> RetrieveRelevant(string query, float[] queryEmbedding, int topK = 5);

    /// <summary>Найти записи с временными метками.</summary>
    Task<List<(string Text, float Score, DateTime Timestamp)>> RetrieveRelevantWithTimestamp(string query,
        float[] queryEmbedding, int topK);
}
```


## TextGenerator.Core\Interfaces\Narrative\INarrativeAgent.cs

```cs
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Core.Interfaces.Narrative;

/// <summary>
/// Основной генератор диалогов и квестов на основе LLM, памяти и контекста мира.
/// </summary>
public interface INarrativeAgent
{
    /// <summary>Сгенерировать ветку диалога для заданного NPC и игрока.</summary>
    Task<DialogueNode> GenerateDialogue(SmartNPC npc, Player player, DialogueNode? parentNode, int? depth, int variety);
    
    /// <summary>Сгенерировать квест на основе описания цели.</summary>
    Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription);

    /// <summary>Генерация диалога без указания родительского узла и глубины (stepped mode, depth=null). Генерация root.</summary>
    Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        int variety);

    /// <summary>Генерация диалога с указанием родительского узла, но без глубины (stepped mode)</summary>
    public Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        DialogueNode parentNode,
        int variety);

    /// <summary>Генерация диалога с указанием глубины, но без родительского узла (branched mode)</summary>
    public Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        int? depth,
        int variety);
}
```


## TextGenerator.Core\Interfaces\Narrative\INarrativeEnvironment.cs

```cs
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Actors;

namespace TextGenerator.Core.Interfaces.Narrative;

/// <summary>
/// Предоставляет актуальный контекст игрового мира (локация, события, состояния, отношения).
/// </summary>
public interface INarrativeEnvironment
{
    /// <summary>Получить релевантный контекст для текущего ввода игрока.</summary>
    Task<WorldContext> GetRelevantContext(SmartNPC npc, Player player, string currentInput);
    
    /// <summary>Обновить состояние сущности в мире.</summary>
    Task UpdateState(string entityId, string property, object value);
    
    /// <summary>Получить социальные связи NPC.</summary>
    Task<IEnumerable<SocialConnection>> GetRelationships(int npcId);
    
    /// <summary>Записать событие взаимодействия в лог мира.</summary>
    Task LogInteraction(string description, DateTime timestamp);
}
```


## TextGenerator.Core\Interfaces\Processors\IDialogueValidator.cs

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator.Core.Interfaces.Processors
{
    /// <summary>
    /// Проверка корректности сгенерированных диалогов (синтаксис, логика).
    /// </summary>
    public interface IDialogueValidator
    {
        /// <summary>Проверить список веток диалога на корректность.</summary>
        public bool CheckCorrections(List<string> dialogueBranches);
    }
}
```


## TextGenerator.Core\Interfaces\Processors\ILLMPromptBuilder.cs

```cs
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Interfaces.Processors
{
    /// <summary>
    /// Построение промптов для различных типов генерации (диалоги, квесты).
    /// </summary>
    public interface ILLMPromptBuilder
    {
        /// <summary>Промпт для генерации ветвистого диалога с заданной глубиной и вариативностью.</summary>
        Task<string> BuildBranchedDialoguePromptAsync(SmartNPC npc, int? depth, int variety);
        
        /// <summary>Промпт для генерации квеста на основе описания цели.</summary>
        Task<string> BuildQuestPromptAsync(SmartNPC npc, Player player, string goalDescription);
        
        /// <summary>Промпт для генерации следующего шага диалога с учётом предыдущего узла.</summary>
        Task<string> BuildSteppedDialoguePromptAsync(SmartNPC npc, DialogueNode prevNode, int variety, WorldContext context);
        Task<string> BuildIntroductoryPhrasePromptAsync(SmartNPC npc);
        string BuildSystemPrompt(SmartNPC npc);
    }
}
```


## TextGenerator.Core\Interfaces\Processors\ILLMResponseParser.cs

```cs
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Core.Interfaces.Processors
{
    /// <summary>
    /// Разбор ответов языковой модели в структурированные объекты (диалоги, квесты).
    /// </summary>
    public interface ILLMResponseParser
    {
        /// <summary>Разобрать ответ для ветвистого диалога (несколько вариантов).</summary>
        Task<DialogueNode> ParseBranchedDialogueResponse(SmartNPC npc, string response);
        
        /// <summary>Разобрать ответ для пошагового диалога (один следующий шаг).</summary>
        Task ParseSteppedDialogueResponse(SmartNPC npc, DialogueNode parentNode, string response);

        /// <summary>Разобрать JSON-ответ в объект квеста.</summary>
        Task<Quest> ParseQuestResponse(string response);
    }
}
```


## TextGenerator.Core\Interfaces\Processors\IPostprocessor.cs

```cs
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Core.Interfaces.Processors;

/// <summary>
/// Разбор ответов языковой модели в структурированные объекты (диалоги, квесты).
/// </summary>
public interface IPostprocessor
{
    /// <summary>
    /// Парсит ответ LLM в древовидную структуру диалога
    /// </summary>
    DialogueNode ParseBranchedDialogueResponse(SmartNPC npc, string rawResponse);
    
    /// <summary>
    /// Парсит ответ LLM для одного шага диалога
    /// </summary>
    void ParseSteppedDialogueResponse(SmartNPC npc, DialogueNode parentNode, string rawResponse);
    
    /// <summary>
    /// Парсит ответ LLM в объект Quest
    /// </summary>
    Quest ParseQuestResponse(string rawResponse);
}
```


## TextGenerator.Core\Interfaces\Processors\IPreprocessor.cs

```cs
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Interfaces.Processors;

/// <summary>
/// Построение промптов для различных типов генерации (диалоги, квесты).
/// </summary>
public interface IPreprocessor
{
    /// <summary>
    /// Генерация промпта для разветвлённого диалога (одним запросом)
    /// </summary>
    string BuildBranchedDialoguePrompt(SmartNPC npc, int? depth, int variety);
    
    /// <summary>
    /// Генерация промпта для пошагового диалога (step-by-step)
    /// </summary>
    string BuildSteppedDialoguePrompt(SmartNPC npc, DialogueNode? prevNode, int variety, WorldContext context);
    
    /// <summary>
    /// Генерация промпта для квеста
    /// </summary>
    string BuildQuestPrompt(SmartNPC npc, Player player, string goalDescription);
    
    /// <summary>
    /// Генерация вступительной фразы NPC
    /// </summary>
    string BuildIntroductoryPhrasePrompt(SmartNPC npc);

    string BuildSystemPrompt(SmartNPC npc);
}
```


## TextGenerator.Core\Interfaces\RAG\IRAGService.cs

```cs
namespace TextGenerator.Core.Interfaces.RAG;

/// <summary>
/// Усиление промпта релевантными воспоминаниями из векторной памяти (RAG).
/// </summary>
public interface IRAGService
{
    /// <summary>Дополнить базовый промпт контекстом, извлечённым из памяти.</summary>
    Task<string> AugmentPrompt(string userQuery, string basePrompt);
    
    /// <summary>Сохранить взаимодействие в память для будущего использования.</summary>
    Task StoreInteraction(string text, string metadata);
}
```


## TextGenerator.Core\Interfaces\RL\IModelFineTuner.cs

```cs
namespace TextGenerator.Core.Interfaces.RL;

/// <summary>
/// Периодическое дообучение языковой модели на собранных данных обратной связи (RLHF/DPO).
/// </summary>
public interface IModelFineTuner
{
    /// <summary>Запустить процесс дообучения, если накоплено достаточно данных.</summary>
    Task RunPeriodicFineTuningAsync();
}
```


## TextGenerator.Core\Models\Actions\GameAction.cs

```cs
using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Actions
{
    public class GameAction : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
```


## TextGenerator.Core\Models\Actions\GameReaction.cs

```cs
using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Actions
{
    public class GameReaction : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
```


## TextGenerator.Core\Models\Actions\SocialConnection.cs

```cs
using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Actors;

namespace TextGenerator.Core.Models.Actions
{
    public class SocialConnection : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public SmartNPC RelatedNPC { get; set; }

        public string Type { get; set; }
        public string Relationships { get; set; }
    }
}
```


## TextGenerator.Core\Models\Actors\Player.cs

```cs
using System.Numerics;
using TextGenerator.Core.Common;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.World;

namespace TextGenerator.Core.Models.Actors
{
    public class Player : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Type { get; set; }
        public Vector3 Position { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public Inventory Inventory { get; set; }
        public List<DialogueNode> Dialogues { get; set; }
        public List<GameReaction> Reactions { get; set; }
        public List<GameAction> Actions { get; set; }
    }
}
```


## TextGenerator.Core\Models\Actors\SmartNPC.cs

```cs
using TextGenerator.Core.Common;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Models.Actors
{
    public class SmartNPC : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Type { get; set; } // Герой, злодей и т.д.
        public int Age { get; set; } //возраст
        public string Appearance { get; set; } // Простое описание по типу внешности
        public string Profession { get; set; }
        public List<string> PersonalCharacteristics { get; set; } // список личностных качеств
        public List<SocialConnection> SocialConnections { get; set; } // Связаннае NPC, тип их связи(муж, работник и т.д.), взаимоотношения
        public List<string> Behaviors { get; set; } // Это может включать типы поведения NPC, например, "агрессивное", "пассивное", "нейтральное", и т.д.
        public List<DialogueNode> Dialogues { get; set; }
        public List<GameReaction> Reactions { get; set; }
        public List<GameAction> Actions { get; set; }
    }
}
```


## TextGenerator.Core\Models\Actors\WorldContext.cs

```cs
namespace TextGenerator.Core.Models.Actors;

public class WorldContext
{
    public string LocationDescription { get; set; }
    public List<string> RecentEvents { get; set; }
    public Dictionary<string, string> EntityStates { get; set; }
    public float TimeOfDay { get; set; }
}
```


## TextGenerator.Core\Models\Feedback\InteractionFeedback.cs

```cs
using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Feedback;

public class InteractionFeedback : IEntity
{
    public string Prompt { get; set; }
    public string GeneratedResponse { get; set; }
    public float Reward { get; set; }
    public Dictionary<string, float> Metrics { get; set; } = new();
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        
    // Дополнительные поля для сбора неявной обратной связи
    public int PlayerChoiceIndex { get; set; } = -1;      // какую ветку выбрал игрок
    public double TimeToRespondMs { get; set; }           // время чтения/выбора
    public bool QuestAccepted { get; set; }               // для квестов
    public TimeSpan QuestCompletionTime { get; set; }     // время выполнения квеста
    public Guid Id { get; } = Guid.NewGuid();
}
```


## TextGenerator.Core\Models\Interactions\Dialogues\DialogueNode.cs

```cs
using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Interactions.Dialogues
{
    public class DialogueNode : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string InterlocutorNPC { get; set; }
        public string InterlocutorPlayer { get; set; }
        public string Name { get; set; }
        public string NPCText { get; set; }
        public string PlayerText { get; set; }
        public List<DialogueNode> Childs { get; set; }
        
        public void AddChild(DialogueNode child)
        {
            Childs ??= new List<DialogueNode>();
            if (!Childs.Contains(child))
                Childs.Add(child);
        }
    }
}
```


## TextGenerator.Core\Models\Interactions\Quests\Quest.cs

```cs
using TextGenerator.Core.Common;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Core.Models.Interactions.Quests
{
    public class Quest : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Difficulty { get; set; }
        public List<Requirement> Requirements { get; set; }
        public List<Reward> Rewards { get; set; }
        public List<DialogueNode> Dialogues { get; set; }
    }
}
```


## TextGenerator.Core\Models\Interactions\Quests\QuestChain.cs

```cs
using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Interactions.Quests
{
    public class QuestChain : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
```


## TextGenerator.Core\Models\Interactions\Quests\Requirement.cs

```cs
using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Interactions.Quests
{
    public class Requirement : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
```


## TextGenerator.Core\Models\Interactions\Quests\Reward.cs

```cs
using TextGenerator.Core.Common;
using TextGenerator.Core.Models.World;

namespace TextGenerator.Core.Models.Interactions.Quests
{
    public class Reward : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public Item RelatedItem { get; set; }
    }
}
```


## TextGenerator.Core\Models\Metrics\PersonalizationMetrics.cs

```cs
namespace TextGenerator.Core.Models.Metrics;

public class PersonalizationMetrics
{
    public float PersonalizationCoefficient { get; set; } // P
    public float DynamicAdaptationCoefficient { get; set; } // D
}

public static class MetricsCalculator
{
    public static float ComputeP(Dictionary<string, float> relevances, Dictionary<string, float> weights)
    {
        float sum = 0;
        foreach (var kv in relevances)
            if (weights.ContainsKey(kv.Key)) sum += kv.Value * weights[kv.Key];
        return sum / weights.Values.Sum();
    }
    
    public static float ComputeD(float actualComplexity, float expectedComplexity, float maxComplexity)
    {
        return 1 - (Math.Abs(actualComplexity - expectedComplexity) / maxComplexity);
    }
}
```


## TextGenerator.Core\Models\World\GameObject.cs

```cs
using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;

namespace TextGenerator.Core.Models.World
{
    public class GameObject : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public IEnumerable<Stat>? Stats { get; set; }
        public ItemType GameObjectType { get; set; }
        public string History { get; set; }
    }
}
```


## TextGenerator.Core\Models\World\Inventory.cs

```cs
using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.World
{
    public class Inventory : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public int OwnerID { get; set; } // Ссылка на владельца инвентаря
        public List<Item> Items { get; set; }
    }
}
```


## TextGenerator.Core\Models\World\Item.cs

```cs
using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;

namespace TextGenerator.Core.Models.World
{
    public class Item : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
    }
}
```


## TextGenerator.Core\Models\World\Stat.cs

```cs
using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;

namespace TextGenerator.Core.Models.World
{
    public class Stat : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public StatType StatType { get; set; }
        public float Value { get; set; }
    }
}
```


## TextGenerator.Core\TextGenerator.Core.csproj

```csproj
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
	<LangVersion>latest</LangVersion>
	<GeneratePackageOnBuild>true</GeneratePackageOnBuild>
	<PackageId>gpt-text-generator-entities</PackageId>
	<Title>GPTTextGenerator.Entites</Title>
	<Authors>InanisPluvia</Authors>
	<PackageOutputPath>C:\Users\LordVT\Desktop\FinalQualifyingWork\src\csharp\NugetRepo</PackageOutputPath>
	<Version>1.1.18</Version>
	<Nullable>enable</Nullable>
	  <GeneratePackageOnBuild>false</GeneratePackageOnBuild>
  </PropertyGroup>

	<ItemGroup>
		<Content Include="..\models\**\*">
			<Link>models\%(RecursiveDir)%(Filename)%(Extension)</Link>
			<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
		</Content>
	</ItemGroup>
</Project>
```


## TextGenerator.Infrastructure\Caching\DialogueCache.cs

```cs
using Microsoft.Extensions.Caching.Memory;
using TextGenerator.Core.Interfaces.Cache;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Infrastructure.Caching;

/// <summary>
/// Реализация кэша диалогов на основе IMemoryCache.
/// </summary>
public class DialogueCache : IDialogueCache
{
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _defaultTtl = TimeSpan.FromMinutes(15);
    
    public DialogueCache(IMemoryCache cache) => _cache = cache;
    
    public bool TryGet(string key, out DialogueNode entry) => _cache.TryGetValue(key, out entry);
    public void Set(string key, DialogueNode entry, TimeSpan? ttl = null) 
        => _cache.Set(key, entry, ttl ?? _defaultTtl);
    
    public string MakeKey(SmartNPC npc, Player player, string playerInput, string contextHash)
        => $"dial_{npc.Id}_{player.Id}_{playerInput.GetHashCode()}_{contextHash}";
}
```


## TextGenerator.Infrastructure\EdgeAI\LLamaSharpOptions.cs

```cs
namespace TextGenerator.Infrastructure.EdgeAI;

public class LLamaSharpOptions
{
    public string ModelPath { get; set; } = "models/Meta-Llama-3-8B.Q4_K_M.gguf";
    
    /// <summary>Количество слоёв, выгружаемых на GPU. 0 = только CPU.</summary>
    public int GpuLayerCount { get; set; } = 5;
    
    /// <summary>Размер контекста (токенов).</summary>
    public uint ContextSize { get; set; } = 2048;
    
    /// <summary>Размер батча для инференса.</summary>
    public uint BatchSize { get; set; } = 512;
}
```


## TextGenerator.Infrastructure\EdgeAI\LocalLLMClient.cs

```cs
using LLama;
using LLama.Common;
using Microsoft.Extensions.Options;
using System.Text;
using LLama.Sampling;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Threading;
using TextGenerator.Core.Interfaces.EdgeAI;

namespace TextGenerator.Infrastructure.EdgeAI;

/// <summary>
/// Клиент для локальной LLama-модели (GGUF).
/// </summary>
public class LocalLLMClient : ILLMClient
{
    private readonly LLamaWeights _weights;
    private readonly LLamaContext _context;
    private readonly LLamaSharpOptions _options;
    private readonly ILogger<LocalLLMClient> _logger;
    private readonly InteractiveExecutor _executor;

    public LocalLLMClient(IOptions<LLamaSharpOptions> options, ILogger<LocalLLMClient> logger)
    {
        _options = options.Value;
        _logger = logger;
        
        var modelPath = GetModelPath("Meta-Llama-3-8B-Instruct.Q4_K_M.gguf");
        _logger.LogInformation("Loading model from {ModelPath}", modelPath);
        
        var parameters = new ModelParams(modelPath)
        {
            ContextSize = _options.ContextSize,
            GpuLayerCount = _options.GpuLayerCount,
            BatchSize = _options.BatchSize
        };
        
        _weights = LLamaWeights.LoadFromFile(parameters);
        _context = _weights.CreateContext(parameters);
        _executor = new InteractiveExecutor(_context);
        _logger.LogInformation("Model loaded successfully");
    }
    
    // private InteractiveExecutor LoadModelAsync(string modelPath)
    // {
    //     _logger.LogInformation("Loading model from {ModelPath}", modelPath);
    //     var parameters = new ModelParams(modelPath)
    //     {
    //         ContextSize = _options.ContextSize,
    //         GpuLayerCount = _options.GpuLayerCount,   // 0 = CPU, >0 = GPU
    //     };
    //     using var model = LLamaWeights.LoadFromFile(parameters);
    //     using var context = model.CreateContext(parameters);
    //     _logger.LogInformation("Model loaded successfully");
    //     return new InteractiveExecutor(context);
    // }

    public async Task<string> GenerateAsync(string prompt, int maxTokens = 256, float temperature = 0.7f)
        => await GenerateWithSystemAsync(prompt, string.Empty, null, maxTokens, temperature);
    
    public async Task<string> GenerateWithSystemAsync(string prompt, string systemPrompt, int? variety, int maxTokens = 256, float temperature = 0.7f)
    {
        int nextNumber = 0;
        if (variety != null)
            nextNumber = (int)(variety + 1);
        
        var chatHistory = new ChatHistory();
        
        // Добавляем системное сообщение, если оно задано
        if (!string.IsNullOrWhiteSpace(systemPrompt))
            chatHistory.AddMessage(AuthorRole.System, systemPrompt);
        
        var session = new ChatSession(_executor, chatHistory);
        
        var inferenceParams = new InferenceParams
        {
            MaxTokens = maxTokens,
            AntiPrompts = nextNumber == 0 ? new[] { "User:" } : new[] { "User:", $"{nextNumber}." },// "Player:", "NPC:", "\n\n" }, // остановка при появлении меток игрока или пустой строки
            SamplingPipeline = new DefaultSamplingPipeline
            {
                TopP = 0.95f,
                RepeatPenalty = 1.0f,
                Temperature = temperature
            }
        };
        
        var result = new StringBuilder();
        
        await foreach (var text in session.ChatAsync(new ChatHistory.Message(AuthorRole.User, prompt), inferenceParams))
        {
            result.Append(text);
        }
        
        return result.ToString().Trim();
    }
    
    private string GetModelPath(string model)
    {
        var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        // Пытаемся найти модель в папке models относительно исполняемого файла
        var relativePath = Path.Combine(baseDir, "models", model);
        if (File.Exists(relativePath))
            return relativePath;
    
        // Запасной вариант: ищем на два уровня выше (корень решения)
        var solutionRoot = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName;
        var absolutePath = Path.Combine(solutionRoot, "models", model);
        if (File.Exists(absolutePath))
            return absolutePath;
    
        throw new FileNotFoundException($"Модель не найдена ни по пути {relativePath}, ни по {absolutePath}");
    }
}
```


## TextGenerator.Infrastructure\EdgeAI\ModelDownloader.cs

```cs
namespace TextGenerator.Infrastructure.EdgeAI;

public class ModelDownloader
{
    public static async Task DownloadModelIfNotExists(string url, string localPath)
    {
        if (File.Exists(localPath)) return;
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        using var fs = new FileStream(localPath, FileMode.CreateNew);
        await response.Content.CopyToAsync(fs);
    }
}
```


## TextGenerator.Infrastructure\Extensions\DialogueExtensions.cs

```cs
using TextGenerator.Core.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Infrastructure.Extensions
{
    public static class DialogueExtensions
    {
        public static void AddChild(this DialogueNode parent, DialogueNode child)
        {
            parent.Childs ??= new List<DialogueNode>();
            if (!parent.Childs.Contains(child))
                parent.Childs.Add(child);
        }

        public static DialogueNode GetDialogueNodeByName(this DialogueNode root, string name)
        {
            if (root == null) throw new ArgumentNullException(nameof(root));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            return GetDialogueNodeByNameRecursive(root, name, 0);
        }

        private static DialogueNode GetDialogueNodeByNameRecursive(DialogueNode node, string name, int currentLevel)
        {
            var targetParts = name.Split('.');
            if (currentLevel >= targetParts.Length) return null;

            string currentPart = targetParts[currentLevel];
            foreach (var child in node.Childs)
            {
                var childParts = child.Name?.Split('.');
                if (childParts != null && childParts.Length > currentLevel && childParts[currentLevel] == currentPart)
                {
                    if (currentLevel + 1 == targetParts.Length)
                        return child;
                    else
                        return GetDialogueNodeByNameRecursive(child, name, currentLevel + 1);
                }
            }
            return null;
        }
    }
}
```


## TextGenerator.Infrastructure\Memory\EmbeddingGeneratorService.cs

```cs
using AllMiniLmL6V2Sharp;
using TextGenerator.Core.Interfaces.Memory;

namespace TextGenerator.Infrastructure.Memory;

/// <summary>
/// Генератор эмбеддингов с помощью ONNX-модели (например, all-MiniLM-L6-v2).
/// </summary>
public class EmbeddingGeneratorService : IEmbeddingGenerator
{
    private readonly AllMiniLmL6V2Embedder _embedder;

    public EmbeddingGeneratorService()
    {
        // Получаем директорию, где находится исполняемый файл (TextGenerator.Service)
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var modelPath = Path.Combine(baseDirectory, "models", "all-MiniLM-L6-v2", "model.onnx");
            
        if (!File.Exists(modelPath))
            throw new FileNotFoundException($"Модель не найдена: {modelPath}");
            
        _embedder = new AllMiniLmL6V2Embedder(modelPath);
    }

    public float[] GetEmbedding(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return Array.Empty<float>();

        // Генерация эмбеддинга для одного предложения
        var embedding = _embedder.GenerateEmbedding(text);
        var arr = embedding.ToArray();
        Console.WriteLine($"Embedding generated for text: '{text.Substring(0, Math.Min(20, text.Length))}...', dimension: {arr.Length}");
        return arr;
    }
}
```


## TextGenerator.Infrastructure\Memory\QdrantVectorMemoryStore.cs

```cs
using Google.Protobuf.Collections;
using Qdrant.Client;
using Qdrant.Client.Grpc;
using TextGenerator.Core.Interfaces.Memory;

namespace TextGenerator.Infrastructure.Memory;

/// <summary>
/// Реализация векторного хранилища на базе Qdrant.
/// </summary>
    public class QdrantVectorMemoryStore : IVectorMemoryStore
    {
        private readonly QdrantClient _client;
        private const string CollectionName = "game_memories";

        public QdrantVectorMemoryStore(string host = "localhost", int port = 6334)
        {
            _client = new QdrantClient(host, port);
            EnsureCollectionExists().GetAwaiter().GetResult();
        }

        private async Task EnsureCollectionExists()
        {
            var collections = await _client.ListCollectionsAsync();
            if (!collections.Contains(CollectionName))
            {
                await _client.CreateCollectionAsync(CollectionName,
                    new VectorParams { Size = 384, Distance = Distance.Cosine });
            }
        }

        public async Task AddMemory(string text, float[] embedding, string metadata)
        {
            var point = new PointStruct
            {
                Id = Guid.NewGuid(),
                Vectors = embedding,
                Payload =
                {
                    ["text"] = new Value { StringValue = text },
                    ["metadata"] = new Value { StringValue = metadata },
                    ["timestamp"] = new Value { IntegerValue = DateTime.UtcNow.Ticks }   // добавлено
                }
            };
            
            await _client.UpsertAsync(CollectionName, new[] { point });
        }

        public async Task<List<(string Text, float Score)>> RetrieveRelevant(string query, float[] queryEmbedding, int topK = 5)
        {
            var vectorMemory = new ReadOnlyMemory<float>(queryEmbedding);
            var searchResult = await _client.SearchAsync(CollectionName, vectorMemory, limit: (ulong)topK);

            var result = new List<(string Text, float Score)>();
            foreach (var scoredPoint in searchResult)
            {
                if (scoredPoint.Payload.TryGetValue("text", out var textValue))
                {
                    var text = textValue.StringValue ?? string.Empty;
                    result.Add((text, scoredPoint.Score));
                }
            }
            return result;
        }
        
        public async Task<List<(string Text, float Score, DateTime Timestamp)>> RetrieveRelevantWithTimestamp(string query, float[] queryEmbedding, int topK)
        {
            var searchResult = await _client.SearchAsync(CollectionName, queryEmbedding, limit: (ulong)topK);
    
            var result = new List<(string Text, float Score, DateTime Timestamp)>();
            foreach (var scoredPoint in searchResult)
            {
                if (scoredPoint.Payload.TryGetValue("text", out var textValue) &&
                    scoredPoint.Payload.TryGetValue("timestamp", out var tsValue))
                {
                    var text = textValue.StringValue ?? string.Empty;
                    var timestamp = tsValue.HasIntegerValue
                        ? new DateTime(tsValue.IntegerValue, DateTimeKind.Utc)
                        : DateTime.MinValue;
                    result.Add((text, scoredPoint.Score, timestamp));
                }
            }
            return result;
        }
    }
```


## TextGenerator.Infrastructure\Memory\TextSummarizer.cs

```cs
using TextGenerator.Core.Interfaces.EdgeAI;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Infrastructure.EdgeAI;

namespace TextGenerator.Infrastructure.Memory;

/// <summary>
/// Суммаризация текста через локальную LLM.
/// </summary>
public class TextSummarizer : ITextSummarizer
{
    private readonly ILLMClient _llm;

    public TextSummarizer(ILLMClient llm) => _llm = llm;

    public async Task<string> Summarize(string longText)
    {
        var prompt = $"Briefly retell the following dialogue or event (no more than 2 sentences):\n{longText}";
        return await _llm.GenerateAsync(prompt, maxTokens: 100);
    }
}
```


## TextGenerator.Infrastructure\Narrative\Agents\NarrativeAgent.cs

```cs
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TextGenerator.Core.Interfaces.EdgeAI;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Interfaces.RAG;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Infrastructure.Narrative.Agents;

/// <summary>
/// Основной генератор диалогов и квестов, использующий LLM, RAG, кэш и контекст мира.
/// </summary>
public class NarrativeAgent : INarrativeAgent
{
    private readonly ILLMClient _llm;
    private readonly IPreprocessor _preprocessor;
    private readonly IPostprocessor _postprocessor;
    private readonly IRAGService _rag; 
    private readonly IMemoryCache _cache;
    private readonly INarrativeEnvironment _narrativeEnv;
    private readonly ILogger<NarrativeAgent> _logger;
        
    // Храним последний узел диалога для каждой пары (NPC, Player)
    private readonly ConcurrentDictionary<(int npcId, int playerId), DialogueNode> _lastNode = new();

    public NarrativeAgent(ILLMClient llm, IPreprocessor preprocessor, IPostprocessor postprocessor,
        IRAGService rag, IMemoryCache cache, INarrativeEnvironment narrativeEnv,
        ILogger<NarrativeAgent> logger)
    {
        _llm = llm;
        _preprocessor = preprocessor;
        _postprocessor = postprocessor;
        _rag = rag;
        _cache = cache;
        _narrativeEnv = narrativeEnv;
        _logger =  logger;
    }

    public async Task<DialogueNode> GenerateDialogue(SmartNPC npc, Player player, DialogueNode? parentNode, int? depth, int variety)
    {
        var systemPrompt = _preprocessor.BuildSystemPrompt(npc);
            
        // Определяем playerInput на основе выбранного узла
        string playerInput = parentNode?.PlayerText ?? string.Empty;
            
        // Формируем ключ кэша с учётом parentNode (если есть)
        var parentHash = parentNode?.Id.ToString() ?? "null";
        var cacheKey = $"dial_{npc.Id}_{player.Id}_{playerInput.GetHashCode()}_{depth}_{variety}_{parentHash}";
            
        if (_cache.TryGetValue(cacheKey, out DialogueNode? cached))
            return cached!;

        // 2. Получение релевантного контекста из NarrativeEnvironment
        var context = await _narrativeEnv.GetRelevantContext(npc, player, playerInput);
            
        DialogueNode result;

        if (depth is <= 1 or null)
        {
            // STEPPED MODE
            // Если нет последнего узла, создаём пустой корневой узел (начальную фразу NPC нужно получить отдельно)
            // В реальности LLM должна сгенерировать сначала корневую фразу, а затем варианты.
            // Упрощённо: создаём корневой узел с пустым NPCText, затем вызываем парсер.
            var currentNode = parentNode ?? new DialogueNode 
            { 
                Name = "0", 
                InterlocutorNPC = npc.Name, 
                Childs = new List<DialogueNode>() 
            };
                
            if (parentNode == null)
            {
                _logger.LogDebug("Creating intro phrase");
                // Вступительная фраза – возвращает string
                currentNode.NPCText = ExtractNpcPhrase(await ProcessWithPipeline(
                    playerInput,
                    systemPrompt,
                    variety,
                    () => _preprocessor.BuildIntroductoryPhrasePrompt(npc),
                    512,
                    raw => raw  // без постобработки, просто строка
                    ), npc.Name);
                _logger.LogDebug("Intro phrase: {phrase}", currentNode.NPCText);
            }
                
            _logger.LogDebug("Make step");
            // Stepped режим – постобработчик добавляет варианты в currentNode
            await ProcessWithPipeline(
                playerInput,
                systemPrompt,
                variety,
                () => _preprocessor.BuildSteppedDialoguePrompt(npc, currentNode, variety, context),
                1024,
                raw =>
                {
                    _postprocessor.ParseSteppedDialogueResponse(npc, currentNode, raw);
                    // Если модель сгенерировала больше вариантов, обрезаем до variety
                    if (currentNode.Childs != null && currentNode.Childs.Count > variety)
                    {
                        _logger.LogWarning("Model generated {Generated} options, expected {Variety}. Truncating.",
                            currentNode.Childs.Count, variety);
                        currentNode.Childs = currentNode.Childs.Take(variety).ToList();
                    }
                    return raw;
                }
            );
    
            result = currentNode;
        }
        else
        {
            // Branched режим
            result = await BuildBranchedDialogueUsingSteps(npc, player, depth.Value, variety);
        }

        // 7. Сохраняем в кэш
        _cache.Set(cacheKey, result, TimeSpan.FromMinutes(10));

        // 8. Сохраняем в память (RAG)
        await _rag.StoreInteraction($"(Player chose: {playerInput}) NPC:{npc.Name} said: {result.NPCText}", 
            $"depth={depth}_variety={variety}");
        return result;
    }
        
    /// <summary>
    /// Строит ветвистое дерево диалога заданной глубины,
    /// последовательно вызывая перегрузки GenerateDialogue для каждого узла.
    /// </summary>
    private async Task<DialogueNode> BuildBranchedDialogueUsingSteps(
        SmartNPC npc, Player player, int maxDepth, int variety)
    {
        _logger.LogInformation(
            "Building branched dialogue iteratively: maxDepth={MaxDepth}, variety={Variety}", maxDepth, variety);

        // 1. Получаем корневой узел с вступительной фразой и первыми дочерними вариантами (глубина 1)
        //    Используем перегрузку без parentNode и depth.
        DialogueNode root = await GenerateDialogue(npc, player, variety);

        // Если корень уже имеет дочерние узлы, но глубина равна 1 – возвращаем как есть
        if (maxDepth == 1)
            return root;

        // 2. Обход в ширину (BFS) по узлам, пока не достигнем maxDepth
        var queue = new Queue<(DialogueNode node, int currentDepth)>();
        foreach (var child in root.Childs ?? Enumerable.Empty<DialogueNode>())
            queue.Enqueue((child, 1));

        while (queue.Count > 0)
        {
            var (node, depth) = queue.Dequeue();
            if (depth >= maxDepth)
                continue;

            _logger.LogDebug("Generating children for node '{NodeName}' at depth {Depth}", node.Name, depth);

            // 3. Для каждого узла вызываем stepped-генерацию (перегрузка с parentNode)
            //    Она сама добавит дочерние узлы в node.Childs.
            await GenerateDialogue(npc, player, node, variety);

            // 4. Добавляем новые дочерние узлы в очередь для дальнейшего раскрытия
            if (node.Childs == null) continue;
            foreach (var child in node.Childs)
                queue.Enqueue((child, depth + 1));
        }

        return root;
    }
        
    public async Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription)
    {
        var prompt = _preprocessor.BuildQuestPrompt(npc, player, goalDescription); // новый метод в LLMPromptBuilder
        var rawQuest = await _llm.GenerateWithSystemAsync(
            prompt, _preprocessor.BuildSystemPrompt(npc), null, maxTokens: 1024);
        _logger.LogDebug("Raw quest response: {Response}", rawQuest);
        var quest = _postprocessor.ParseQuestResponse(rawQuest);
        await _rag.StoreInteraction($"Сгенерирован квест: {quest.Name}", $"NPC={npc.Name}");
        return quest;
    }
        
    public Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        int variety)
        => GenerateDialogue(npc, player, null, null, variety);
        
    public Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        DialogueNode parentNode,
        int variety)
        => GenerateDialogue(npc, player, parentNode, null, variety);
        
    public Task<DialogueNode> GenerateDialogue(
        SmartNPC npc,
        Player player,
        int? depth,
        int variety)
        => GenerateDialogue(npc, player, null, depth, variety);
        
    private async Task<T> ProcessWithPipeline<T>(
        string playerInput,
        string systemPrompt,
        int variety,
        Func<string> buildPrompt,           // фабрика промпта (синхронная, но может быть async)
        int maxTokens,
        Func<string, T> postprocess         // постобработка ответа LLM
    )
    {
        _logger.LogInformation("ProcessWithPipeline started. PlayerInput: {PlayerInput}, MaxTokens: {MaxTokens}", 
            playerInput?.Length > 50 ? playerInput[..50] + "..." : playerInput, maxTokens);
            
        // 3. Формирование промпта для следующего шага
        var prompt = buildPrompt();
        _logger.LogDebug("Generated prompt length: {PromptLength} characters", prompt.Length);
            
        _logger.LogDebug("Generated prompt length: {PromptLength} characters", prompt.Length);
            
        // 4. RAG-усиление
        var stopwatch = Stopwatch.StartNew();
        var augmented = await _rag.AugmentPrompt(playerInput, prompt);
        stopwatch.Stop();
        _logger.LogInformation("RAG augmentation completed in {ElapsedMs} ms. Augmented prompt length: {Length}", 
            stopwatch.ElapsedMilliseconds, augmented.Length);
            
        // 5. Генерация через локальную LLM
        stopwatch.Restart();
        stopwatch.Restart();
        string rawResponse;
        try
        {
            rawResponse = await _llm.GenerateWithSystemAsync(augmented, systemPrompt, variety, maxTokens);
            stopwatch.Stop();
            _logger.LogInformation("LLM generation completed in {ElapsedMs} ms. Response length: {ResponseLength}", 
                stopwatch.ElapsedMilliseconds, rawResponse.Length);
            _logger.LogTrace("LLM raw response: {RawResponse}", 
                rawResponse.Length > 200 ? rawResponse[..200] + "..." : rawResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "LLM generation failed after {ElapsedMs} ms", stopwatch.ElapsedMilliseconds);
            throw;
        }
            
        _logger.LogDebug("Augmented prompt: {Prompt}", augmented);
        _logger.LogDebug("Raw LLM response: {Response}", rawResponse);
    
        // Постобработка
        T result;
        try
        {
            result = postprocess(rawResponse);
            _logger.LogInformation("Postprocessing completed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Postprocessing failed for response: {RawResponse}", 
                rawResponse.Length > 200 ? rawResponse[..200] + "..." : rawResponse);
            throw;
        }
        return result;
    }

    // Альтернатива: если buildPrompt асинхронный
    private async Task<T> ProcessWithPipelineAsync<T>(
        string playerInput,
        Func<Task<string>> buildPromptAsync,
        int maxTokens,
        Func<string, T> postprocess
    )
    {
        // 3. Формирование промпта для следующего шага
        var prompt = await buildPromptAsync();
            
        // 4. RAG-усиление
        var augmented = await _rag.AugmentPrompt(playerInput, prompt);
            
        // 5. Генерация через локальную LLM
        var rawResponse = await _llm.GenerateAsync(augmented, maxTokens);
            
        // 6. Постобработка – получаем диалог
        return postprocess(rawResponse);
    }
        
    private string ExtractNpcPhrase(string rawResponse, string npcName)
    {
        if (string.IsNullOrWhiteSpace(rawResponse))
            return string.Empty;

        // Получаем сокращённое имя (первое слово)
        string shortName = npcName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
    
        // Функция для попытки извлечения фразы по заданному имени и паттерну
        string TryExtract(string name, bool requireQuotes)
        {
            if (string.IsNullOrEmpty(name))
                return null;
        
            string pattern;
            if (requireQuotes)
                pattern = $@"{Regex.Escape(name)}:\s*""(?<phrase>[^""]+)""";
            else
                pattern = $@"{Regex.Escape(name)}:\s*(?<phrase>[^""]+)";
        
            var match = Regex.Match(rawResponse, pattern);
            return match.Success ? match.Groups["phrase"].Value : null;
        }

        // 1. Точное полное имя, текст в кавычках
        string result = TryExtract(npcName, true);
        if (result != null) return result;

        // 2. Точное полное имя, текст без кавычек
        result = TryExtract(npcName, false);
        if (result != null) return result;

        // 3. Сокращённое имя (первое слово), текст в кавычках
        result = TryExtract(shortName, true);
        if (result != null) return result;

        // 4. Сокращённое имя, текст без кавычек
        result = TryExtract(shortName, false);
        if (result != null) return result;

        // 5. Просто текст в двойных кавычках (без указания имени)
        var match = Regex.Match(rawResponse, @"""(?<phrase>[^""]+)""");
        if (match.Success)
            return match.Groups["phrase"].Value;

        // 6. Обрезаем "User:" в конце, если ничего не нашли
        var trimmed = rawResponse.Trim();
        if (trimmed.EndsWith("User:", StringComparison.OrdinalIgnoreCase))
            trimmed = trimmed.Substring(0, trimmed.Length - 5).Trim();

        return trimmed;
    }
}
```


## TextGenerator.Infrastructure\Narrative\Environment\NarrativeEnvironmentService.cs

```cs
using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using Neo4j.Driver;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Actors;

namespace TextGenerator.Infrastructure.Narrative.Environment;

/// <summary>
/// Реализация получения контекста мира из Neo4j и кэша.
/// </summary>
public class NarrativeEnvironmentService : INarrativeEnvironment
{
    //private readonly IDriver _neo4jDriver;
    //private readonly IMemoryCache _cache;
    //private readonly ConcurrentDictionary<string, byte> _cacheKeys = new();
    //private const string CacheKeyPrefix = "narrative_env_";

    public NarrativeEnvironmentService(
        //IDriver neo4jDriver, 
        //IMemoryCache memoryCache
        )
    {
        //_neo4jDriver = neo4jDriver;
        //_cache = memoryCache;
    }

    public Task<WorldContext> GetRelevantContext(SmartNPC npc, Player player, string currentInput)
    {
        // string cacheKey = $"{CacheKeyPrefix}{npc.Id}_{player.Id}";
        // if (_cache.TryGetValue(cacheKey, out WorldContext cachedContext))
        //     return cachedContext;
        //
        // var context = new WorldContext();
        // await using var session = _neo4jDriver.AsyncSession();
        //
        // // 1. Местоположение и время суток
        // var locationResult = await session.RunAsync(
        //     @"MATCH (n:NPC {id: $npcId})-[:LOCATED_AT]->(loc:Location)
        //       RETURN loc.description AS location, loc.timeOfDay AS timeOfDay",
        //     new { npcId = npc.Id });
        // var locationRecord = await locationResult.SingleAsync();
        // context.LocationDescription = locationRecord["location"].As<string>();
        // context.TimeOfDay = locationRecord["timeOfDay"].As<float>();
        //
        // // 2. Последние 5 событий из истории взаимодействий
        // var eventsResult = await session.RunAsync(
        //     @"MATCH (n:NPC {id: $npcId})-[r:INTERACTED_WITH]->(p:Player {id: $playerId})
        //       RETURN r.description AS event
        //       ORDER BY r.timestamp DESC LIMIT 5",
        //     new { npcId = npc.Id, playerId = player.Id });
        // var events = await eventsResult.ToListAsync();
        // context.RecentEvents = events.Select(r => r["event"].As<string>()).ToList();
        //
        // // 3. Состояния сущностей (например, двери открыта/закрыта)
        // var statesResult = await session.RunAsync(
        //     @"MATCH (e:Entity)
        //       WHERE e.id STARTS WITH 'world_'
        //       RETURN e.id AS entityId, e.state AS state");
        // var states = await statesResult.ToListAsync();
        // context.EntityStates = states.ToDictionary(
        //     s => s["entityId"].As<string>(),
        //     s => s["state"].As<string>());
        //
        // // Make sure to add the key to tracker after setting cache:
        // var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
        // _cache.Set(cacheKey, context, cacheEntryOptions);
        // _cacheKeys.TryAdd(cacheKey, 0);
        // return context;
        
        return Task.FromResult(new WorldContext
        {
            LocationDescription = "A dark forest clearing",
            RecentEvents = new List<string> { "You hear wolves howling in the distance." },
            EntityStates = new Dictionary<string, string> { { "gate", "closed" } },
            TimeOfDay = 0.75f // вечер
        });
    }

    public Task UpdateState(string entityId, string property, object value)
    {
        // await using var session = _neo4jDriver.AsyncSession();
        // await session.RunAsync(
        //     @"MATCH (e:Entity {id: $entityId})
        //       SET e.$property = $value",
        //     new { entityId, property, value });
        // // Инвалидируем кэш, связанный с этой сущностью
        // var keysToRemove = _cacheKeys.Keys.Where(k => k.Contains(entityId)).ToList();
        // foreach (var key in keysToRemove)
        // {
        //     _cache.Remove(key);
        //     _cacheKeys.TryRemove(key, out _);
        // }

        return Task.FromResult(Task.CompletedTask);
    }

    public Task<IEnumerable<SocialConnection>> GetRelationships(int npcId)
    {
        // await using var session = _neo4jDriver.AsyncSession();
        // var result = await session.RunAsync(
        //     @"MATCH (n:NPC {id: $npcId})-[r:RELATED_TO]->(other:NPC)
        //       RETURN other.id AS relatedId, other.name AS relatedName, type(r) AS relationType, r.description AS relationshipDesc",
        //     new { npcId });
        // var records = await result.ToListAsync();
        // var connections = new List<SocialConnection>();
        // foreach (var record in records)
        // {
        //     connections.Add(new SocialConnection
        //     {
        //         ID = 0, // ID не хранится в графе, можно сгенерировать
        //         RelatedNPC = new SmartNPC { ID = record["relatedId"].As<int>(), Name = record["relatedName"].As<string>() },
        //         Type = record["relationType"].As<string>(),
        //         Relationships = record["relationshipDesc"].As<string>()
        //     });
        // }
        // return connections;
        return Task.FromResult(Enumerable.Empty<SocialConnection>());
    }

    public Task LogInteraction(string description, DateTime timestamp)
    {
        // await using var session = _neo4jDriver.AsyncSession();
        // await session.RunAsync(
        //     @"CREATE (e:Event {description: $description, timestamp: $timestamp})",
        //     new { description, timestamp });
        return Task.FromResult(Task.CompletedTask);
    }
}
```


## TextGenerator.Infrastructure\Processors\DialogueValidator.cs

```cs
//using BERTTokenizers;

using FastBertTokenizer;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using TextGenerator.Core.Interfaces.Processors;

namespace TextGenerator.Infrastructure.Processors;

public struct BertInput
{
    public long[] InputIds { get; set; }
    public long[] AttentionMask { get; set; }
    public long[] TypeIds { get; set; }
}

/// <summary>
/// Валидация диалогов с помощью BERT-классификатора (ONNX).
/// </summary>
public class DialogueValidator : IDialogueValidator
{
    private static BertTokenizer tokenizer;
    private InferenceSession _onnxSession;

    public DialogueValidator()
    {
        tokenizer = new BertTokenizer();
        tokenizer.LoadTokenizerJsonAsync("bert-base-uncased").Wait();
        _onnxSession = new InferenceSession("dialogue_classifier.onnx");
    }

    public float ValidateDialogue(long[] inputIds, long[] attentionMask)
    {
        var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input_ids",
                new DenseTensor<long>(inputIds, new[] { 1, inputIds.Length })),
            NamedOnnxValue.CreateFromTensor("attention_mask",
                new DenseTensor<long>(attentionMask, new[] { 1, attentionMask.Length }))
        };

        using var results = _onnxSession.Run(inputs);
        var output = results.First().AsTensor<float>().ToArray();

        return output[0];  // Возвращаем вероятность корректности диалога
    }

    public bool CheckCorrections(List<string> dialogueBranches)
    {
        foreach (var branch in dialogueBranches)
        {
            // Encode the sentence and get the InputIds, AttentionMask and TypeIds.
            var (inputIds, attentionMask, typeIds) = tokenizer.Encode(branch);

            // Run the model.
            var score = ValidateDialogue(inputIds.ToArray(), attentionMask.ToArray());

            if (score < 0.5)
                return false;
        }

        return true;
    }
}
```


## TextGenerator.Infrastructure\Processors\LLMPromptBuilder.cs

```cs
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Interfaces.RAG;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Infrastructure.Processors;

/// <summary>
/// Формирование промптов для языковой модели на основе данных NPC, игрока и контекста.
/// </summary>
public class LLMPromptBuilder : ILLMPromptBuilder
{
    private readonly INarrativeEnvironment _narrativeEnv;
    //private readonly IRAGService _rag;
    private readonly ITextSummarizer _summarizer;
    private readonly PromptOptions _options;

    public LLMPromptBuilder(
        INarrativeEnvironment narrativeEnv,
        //IRAGService rag,
        ITextSummarizer summarizer,
        IOptions<PromptOptions> options)
    {
        _narrativeEnv = narrativeEnv;
        //_rag = rag;
        _summarizer = summarizer;
        _options = options.Value;
    }
        
    public Task<string> BuildBranchedDialoguePromptAsync(SmartNPC npc, int? depth, int variety)
    {
        var npcProfile = BuildNPCProfile(npc);
        var constraints = BuildBranchConstraints(depth, variety);
        var formatInstruction = 
            @"Format each line exactly as: 
              <variant> <PlayerName>: ""<player phrase>"" <NPCName>: ""<npc phrase>""
              Example: 1 Player: ""Hello"" Merchant: ""Welcome!""
              Use numbered variants like 1, 1.1, 1.2, 2, 2.1, etc.";
        
        var prompt = $"""
                      {npcProfile}
                      {constraints}
                      {formatInstruction}
                      Generate a complete branched dialogue tree. Start with level 0 (NPC's opening line).
                      """;
        
        // Улучшение: RAG-усиление базового промпта
        return Task.FromResult(prompt);
    }

    public Task<string> BuildSteppedDialoguePromptAsync(SmartNPC npc, DialogueNode? previousNode, int variety, WorldContext context)
    {
        var prevStep = previousNode != null 
            ? !string.IsNullOrEmpty(previousNode.PlayerText) 
                ? $"Previous: Player said \"{previousNode.PlayerText}\" → {npc.Name} replied \"{previousNode.NPCText}\"" 
                : $"{npc.Name}: \"{previousNode.NPCText}\""
            : "This is the start of conversation.";
    
        var contextInfo = JsonConvert.SerializeObject(context, Formatting.Indented);
    
        var prompt = $"""
                      World context: {contextInfo}
                      {prevStep}

                      Provide {variety} different ways the player could respond, each followed by {npc.Name}'s reply.

                      Format exactly like this example (use double quotes around each phrase):

                      1. Player: "Phrase"
                         {npc.Name}: "Phrase"

                      2. Player: "Phrase"
                         {npc.Name}: "Phrase"

                      (Continue numbering up to {variety}. Replace phrase with your text.)

                      IMPORTANT: Do not include any introductory or concluding text. Start directly with "1.".
                      """;
    
        return Task.FromResult(prompt);
    }

    public async Task<string> BuildQuestPromptAsync(SmartNPC npc, Player player, string goalDescription)
    {
        var context = await _narrativeEnv.GetRelevantContext(npc, player, goalDescription);
    
        var exampleQuest = new
        {
            name = "The Missing Artifact",
            description = "Retrieve the ancient artifact from the goblin camp.",
            difficulty = 2,
            requirements = new[] 
            { 
                new { type = "collect", target = "Ancient Artifact", count = 1 },
                new { type = "kill", target = "Goblin", count = 5 }
            },
            rewards = new[] 
            { 
                new { type = "exp", amount = 150 },
                new { type = "gold", amount = 50 }
            }
        };

        string exampleJson = JsonConvert.SerializeObject(exampleQuest, Formatting.Indented);

        var prompt = $"""
                      You are a NPC that generate quest for a fantasy RPG game.

                      Player: {player.Name}, Level {player.Level}
                      Goal: {goalDescription}
                      World context: {JsonConvert.SerializeObject(context)}

                      Generate a quest as a JSON object. Follow exactly this format:
                      {exampleJson}

                      Output ONLY the JSON object. Do not include any other text.
                      """;

        return prompt;
    }

    public async Task<string> BuildIntroductoryPhrasePromptAsync(SmartNPC npc)
    {
        return "Generate a single opening line to start a conversation. No more than 2 sentences.";
    }

    // Вспомогательные методы
    private string BuildNPCProfile(SmartNPC npc)
    {
        return $"""Name: {npc.Name}. Type: {npc.Type}. Age: {npc.Age}. Appearance: {npc.Appearance}. Profession: {npc.Profession}. Personal characteristics: {string.Join(", ", npc.PersonalCharacteristics)}. Behavior: {string.Join(", ", npc.Behaviors)}.""";
    }
    
    public string BuildSystemPrompt(SmartNPC npc)
    {
        // Используем существующий метод BuildNPCProfile из LLMPromptBuilder
        // Для этого нужно либо внедрить ILLMPromptBuilder, либо вынести формирование профиля в отдельный статический класс.
        // Простейший вариант – скопировать логику сюда (но лучше через DI).
        var profile = BuildNPCProfile(npc);
    
        return $"You are an NPC in an RPG game. Your personality is {profile} Stay in character, speak naturally, and never generate text for the Player. Keep responses concise (one sentence).";
    }

    private string BuildBranchConstraints(int? depth, int variety)
    {
        if (depth == null) return "";
        var sb = new StringBuilder();
        sb.AppendLine($"Generate a dialogue tree of depth {depth} with {variety} branches at each level.");
        sb.AppendLine($"Total leaf nodes: {Math.Pow(variety, (double)depth!)}.");
        sb.AppendLine("Level 0: NPC's opening line.");
        for (int i = 1; i <= depth; i++)
            sb.AppendLine($"Level {i}: For each previous player option, provide {variety} player responses and corresponding NPC replies.");
        return sb.ToString();
    }

    private int EstimateTokenCount(string text) => (int)(text.Length * 0.75);
}

public class PromptOptions
{
    public int MaxPromptTokens { get; set; } = 1800;
}
```


## TextGenerator.Infrastructure\Processors\LLMResponseParser.cs

```cs
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;
using TextGenerator.Infrastructure.Extensions;

namespace TextGenerator.Infrastructure.Processors;

/// <summary>
/// Парсинг ответов LLM в объекты диалогов и квестов.
/// </summary>
public class LLMResponseParser : ILLMResponseParser
{
    private static string npcName = "";
    private static string playerName = "";
    private readonly ILogger<LLMResponseParser> _logger;
    
    public LLMResponseParser(ILogger<LLMResponseParser> logger)
    {
        _logger = logger;
    }

    public async Task<DialogueNode> ParseBranchedDialogueResponse(SmartNPC npc, string response)
    {
        var root = new DialogueNode();
        root.Childs = new List<DialogueNode>();

        string pattern = @"(?<variant>[0]{1})\s+(?<npcName>\w+)\s*:\s*""(?<npcPhrase>[^""]+)""";

        MatchCollection matches = Regex.Matches(response, pattern, RegexOptions.Singleline);

        foreach (Match match in matches)
        {
            root.NPCText = match.Groups["npcPhrase"].Value;
        }

        var result = ParseTextToDict(response);
/*            foreach (var variant in result)
            {
                Console.WriteLine($"Вариант: {variant.Key}");
                foreach (var character in variant.Value)
                {
                    Console.WriteLine($"{character.Key}:");
                    foreach (var phrase in character.Value)
                    {
                        Console.WriteLine($"{phrase.Key}: {phrase.Value}");
                    }
                }
            }*/



        foreach (var line in result)
        {
            var node = new DialogueNode();
            node.Name = line.Key;
            node.Childs = new List<DialogueNode>();
            node.InterlocutorNPC = npcName;
            node.NPCText = line.Value[npcName]["NPC"];
            node.InterlocutorPlayer = playerName;
            node.PlayerText = line.Value[playerName]["Player"];
            var level = line.Key.Split('.', (char)StringSplitOptions.RemoveEmptyEntries).Length;
            //Console.WriteLine(level);

            if (level - 1 == 0)
            {
                root.AddChild(node);
            }
            else
            {
                var parent = root.GetDialogueNodeByName(line.Key.Remove(line.Key.Length - 2));
                parent.AddChild(node);
            }
        }

        return root;
    }

    public async Task<Quest> ParseQuestResponse(string response)
    {
        // Найти первую '{' и последнюю '}'
        int start = response.IndexOf('{');
        int end = response.LastIndexOf('}');
    
        if (start == -1 || end == -1 || start >= end)
        {
            // Логирование сырого ответа для отладки
            _logger?.LogError("No JSON found in LLM response: {Response}", response);
            throw new ArgumentException("No JSON found in LLM response");
        }
    
        string json = response.Substring(start, end - start + 1);
    
        try
        {
            var quest = JsonConvert.DeserializeObject<Quest>(json);
            if (quest == null) throw new JsonException("Deserialized quest is null");
        
            // Валидация полей
            if (quest.Difficulty < 1 || quest.Difficulty > 5)
                quest.Difficulty = 3;
        
            return quest;
        }
        catch (JsonException ex)
        {
            _logger?.LogError(ex, "Failed to parse quest JSON: {Json}", json);
            throw new ArgumentException("Invalid JSON in LLM response", ex);
        }
    }

    public async Task ParseSteppedDialogueResponse(SmartNPC npc, DialogueNode parentNode, string response)
    {
        // Экранируем имя NPC на случай спецсимволов (например, точка в "Dr. Smith")
        string escapedName = Regex.Escape(npc.Name);
    
        // Паттерн: номер. Player: "текст" (любые пробелы/переносы) (NPC|ИмяNPC): "текст"
        string pattern = $@"\d+\.\s*Player:\s*""(?<player>[^""]+)""\s+(?:NPC|{escapedName}):\s*""(?<npcText>[^""]+)""";
        var matches = Regex.Matches(response, pattern, RegexOptions.Multiline);
    
        if (matches.Count == 0)
            throw new FormatException($"No valid stepped responses found in: {response}");
    
        foreach (Match match in matches)
        {
            var childNode = new DialogueNode
            {
                InterlocutorPlayer = "Player",
                PlayerText = match.Groups["player"].Value,
                InterlocutorNPC = npc.Name,
                NPCText = match.Groups["npcText"].Value,
                Childs = new List<DialogueNode>() // дочерние узлы для будущих шагов
            };
            parentNode.AddChild(childNode);
        }
    }

    private Dictionary<string, Dictionary<string, Dictionary<string, string>>> ParseTextToDict(string text)
    {
        string pattern = @"(?<variant>\d.)\s+(?<playerName>\w+)\s*:\s*""(?<playerPhrase>[^""]+)""\s+(?<npcName>\w+)\s*:\s*""(?<npcPhrase>[^""]+)""";
        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.Singleline);

        Dictionary<string, Dictionary<string, Dictionary<string, string>>> groups = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

        foreach (Match match in matches)
        {
            string key = match.Groups["variant"].Value;
            npcName = match.Groups["npcName"].Value;
            string npcPhrase = match.Groups["npcPhrase"].Value;
            playerName = match.Groups["playerName"].Value;
            string playerPhrase = match.Groups["playerPhrase"].Value;

            if (!groups.ContainsKey(key))
            {
                groups[key] = new Dictionary<string, Dictionary<string, string>>();
            }

            if (!groups[key].ContainsKey(playerName))
            {
                groups[key][playerName] = new Dictionary<string, string>();
            }
            groups[key][playerName]["Player"] = playerPhrase;

            if (!groups[key].ContainsKey(npcName))
            {
                groups[key][npcName] = new Dictionary<string, string>();
            }
            groups[key][npcName]["NPC"] = npcPhrase;
        }

        return groups;
    }
}
```


## TextGenerator.Infrastructure\Processors\PostprocessorService.cs

```cs
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Infrastructure.Processors;

public class PostprocessorService : IPostprocessor
{
    private readonly ILLMResponseParser _responseParser;

    public PostprocessorService(ILLMResponseParser responseParser)
    {
        _responseParser = responseParser;
    }
    
    public DialogueNode ParseBranchedDialogueResponse(SmartNPC npc, string rawResponse)
        => _responseParser.ParseBranchedDialogueResponse(npc, rawResponse).GetAwaiter().GetResult();

    public void ParseSteppedDialogueResponse(SmartNPC npc, DialogueNode parentNode, string rawResponse)
        => _responseParser.ParseSteppedDialogueResponse(npc, parentNode, rawResponse).GetAwaiter().GetResult();

    public Quest ParseQuestResponse(string rawResponse)
        => _responseParser.ParseQuestResponse(rawResponse).GetAwaiter().GetResult();
    
    // Obsolete методы для обратной совместимости
    [Obsolete("Use ParseBranchedDialogueResponse")]
    public DialogueNode DecodeAPIBranchedDialogueResponse(SmartNPC npc, string response) 
        => ParseBranchedDialogueResponse(npc, response);
    
    [Obsolete("Use ParseSteppedDialogueResponse")]
    public void DecodeSingleStepDialogueResponse(SmartNPC npc, DialogueNode parentNode, string response) 
        => ParseSteppedDialogueResponse(npc, parentNode, response);
    
    [Obsolete("Use ParseQuestResponse")]
    public Quest ParseQuest(string response) => ParseQuestResponse(response);
}
```


## TextGenerator.Infrastructure\Processors\PreprocessorService.cs

```cs
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Infrastructure.Processors;

public class PreprocessorService : IPreprocessor
{
    private readonly ILLMPromptBuilder _promptBuilder;

    public PreprocessorService(ILLMPromptBuilder promptBuilder)
    {
        _promptBuilder = promptBuilder;
    }

    public string BuildBranchedDialoguePrompt(SmartNPC npc, int? depth, int variety)
        => _promptBuilder.BuildBranchedDialoguePromptAsync(npc, depth, variety).GetAwaiter().GetResult();

    public string BuildSteppedDialoguePrompt(SmartNPC npc, DialogueNode? prevNode, int variety, WorldContext context)
        => _promptBuilder.BuildSteppedDialoguePromptAsync(npc, prevNode, variety, context).GetAwaiter().GetResult();

    public string BuildQuestPrompt(SmartNPC npc, Player player, string goalDescription)
        => _promptBuilder.BuildQuestPromptAsync(npc, player, goalDescription).GetAwaiter().GetResult();

    public string BuildIntroductoryPhrasePrompt(SmartNPC npc)
        => _promptBuilder.BuildIntroductoryPhrasePromptAsync(npc).GetAwaiter().GetResult();

    public string BuildSystemPrompt(SmartNPC npc)
        => _promptBuilder.BuildSystemPrompt(npc);
    
    // Старые методы помечены Obsolete (опционально)
    [Obsolete("Use BuildBranchedDialoguePrompt instead")]
    public string GenerateBasicBranchedDialogueRequest(SmartNPC npc, int depth, int variety)
        => BuildBranchedDialoguePrompt(npc, depth, variety);
    
    [Obsolete("Use BuildSteppedDialoguePrompt instead")]
    public string GenerateBasicSteppedDialogueRequest(SmartNPC npc, DialogueNode prevNode, int variety, WorldContext context)
        => BuildSteppedDialoguePrompt(npc, prevNode, variety, context);
    
    [Obsolete("Use BuildQuestPrompt instead")]
    public string GenerateQuestPrompt(SmartNPC npc, Player player, string goalDescription)
        => BuildQuestPrompt(npc, player, goalDescription);
}
```


## TextGenerator.Infrastructure\RAG\RAGService.cs

```cs
using System.Text;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.RAG;

namespace TextGenerator.Infrastructure.RAG;

/// <summary>
/// Реализация RAG-усиления промпта: извлечение релевантных воспоминаний и их добавление.
/// </summary>
public class RAGService : IRAGService
{
    private readonly IVectorMemoryStore _vectorMemoryStore;
    private readonly IEmbeddingGenerator _vectorizer;
    private readonly ITextSummarizer _textSummarizer;

    public RAGService(IVectorMemoryStore vectorMemoryStore, IEmbeddingGenerator vectorizer, ITextSummarizer textSummarizer)
    {
        _vectorMemoryStore = vectorMemoryStore;
        _vectorizer = vectorizer;
        _textSummarizer = textSummarizer;
    }

    public async Task<string> AugmentPrompt(string userQuery, string basePrompt)
    {
        // Не выполняем RAG для пустого или слишком короткого запроса
        if (string.IsNullOrWhiteSpace(userQuery) || userQuery.Length < 5)
            return basePrompt;
        
        var embedding = _vectorizer.GetEmbedding(userQuery);
        if (embedding == null || embedding.Length == 0)
            return basePrompt;
        
        var memories = await _vectorMemoryStore.RetrieveRelevantWithTimestamp(userQuery, embedding, topK: 3);
    
        if (memories.Count == 0) return basePrompt;
    
        var sorted = memories.OrderByDescending(m => m.Timestamp).Take(3);

        var context = new StringBuilder();
        context.AppendLine("Here is what the NPC remembers about past interactions (recent memories are more important):");
        foreach (var mem in sorted)
            context.AppendLine($"- {mem.Text} ({DateTime.Now.Subtract(mem.Timestamp).TotalHours:F1} hours ago)");

        var fullPrompt = $"{basePrompt}\n\n{context}";

        if (EstimateTokenCount(fullPrompt) <= 1800) return fullPrompt;
        
        var summary = await _textSummarizer.Summarize(context.ToString());
        return $"{basePrompt}\n\nBrief reminder: {summary}";
    }

    public async Task StoreInteraction(string text, string metadata)
    {
        var embedding = _vectorizer.GetEmbedding(text);
        await _vectorMemoryStore.AddMemory(text, embedding, metadata);
    }
    
    private int EstimateTokenCount(string text)
    {
        // Простая эвристика: 1 токен ≈ 4 символов для английского, 2 символа для кириллицы.
        // В реальном проекте используйте настоящий токенизатор (например, LLamaSharp's Tokenizer).
        return (int)(text.Length * 0.75);
    }
}
```


## TextGenerator.Infrastructure\Reward\FeedbackCollector.cs

```cs
using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Models.Feedback;

namespace TextGenerator.Infrastructure.Reward;

/// <summary>
/// Сбор обратной связи в памяти и сохранение в JSON.
/// </summary>
public class FeedbackCollector : IFeedbackCollector
{
    private readonly List<InteractionFeedback> _feedbacks = new();
    private readonly object _lock = new();
    
    public void RecordFeedback(InteractionFeedback feedback)
    {
        lock (_lock) _feedbacks.Add(feedback);
    }

    public Task<List<InteractionFeedback>> GetDatasetAsync()
    {
        lock (_lock) return Task.FromResult(_feedbacks.ToList());
    }

    public async Task SaveToDatasetAsync(string path)
    {
        var json = JsonConvert.SerializeObject(_feedbacks, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);
    }
}
```


## TextGenerator.Infrastructure\Reward\RewardCalculator.cs

```cs
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Processors;

namespace TextGenerator.Infrastructure.Reward;

/// <summary>
/// Вычисление награды для сгенерированной реплики на основе валидации, контекста и стиля.
/// </summary>
public class RewardCalculator : IRewardCalculator
{
    private readonly IDialogueValidator _dialogueDialogueValidator;

    public RewardCalculator(IDialogueValidator dialogueDialogueValidator) => _dialogueDialogueValidator = dialogueDialogueValidator;

    public float CalculateReward(string generatedText, string context, string expectedStyle)
    {
        // 1. Syntactic correctness (0-1)
        float syntaxScore = _dialogueDialogueValidator.CheckCorrections(new List<string> { generatedText }) ? 1.0f : 0.3f;

        // 2. Semantic consistency (simplified: check for presence of context keywords)
        float contextScore = context.Contains(generatedText[..Math.Min(50, generatedText.Length)]) ? 0.8f : 0.5f;

        // 3. Stylistic conformity (imitation)
        float styleScore = generatedText.Contains(expectedStyle) ? 1.0f : 0.4f;

        // Final reward (weights can be tuned)
        return (syntaxScore * 0.4f + contextScore * 0.3f + styleScore * 0.3f);
    }
}
```


## TextGenerator.Infrastructure\RL\ModelFineTuner.cs

```cs
using TextGenerator.Core.Interfaces.EdgeAI;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.RL;

namespace TextGenerator.Infrastructure.RL;

/// <summary>
/// Периодическое дообучение модели на собранных данных.
/// </summary>
public class ModelFineTuner : IModelFineTuner
{
    private readonly IFeedbackCollector _collector;
    private readonly ILLMClient _llm;
    
    public ModelFineTuner(IFeedbackCollector collector, ILLMClient llm)
    {
        _collector = collector;
        _llm = llm;
    }
    
    public async Task RunPeriodicFineTuningAsync()
    {
        // 1. Собрать накопленные данные (prompt, response, reward)
        var dataset = await _collector.GetDatasetAsync();
        if (dataset.Count < 100) return;
        
        // 2. Преобразовать в формат для DPO (например, JSONL)
        // 3. Вызвать внешний скрипт Python (или использовать TorchSharp) для LoRA-дообучения
        // 4. Обновить веса модели (заменить .gguf или LoRA адаптер)
        // Здесь пока заглушка
        Console.WriteLine($"Fine-tuning запущен с {dataset.Count} примерами");
        await Task.CompletedTask;
    }
}
```


## TextGenerator.Infrastructure\TextGenerator.Infrastructure.csproj

```csproj
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <ImplicitUsings>enable</ImplicitUsings>
	<LangVersion>latest</LangVersion>
	<GeneratePackageOnBuild>true</GeneratePackageOnBuild>
	<PackageId>gpt-text-generator-infrastructure</PackageId>
	<Title>GPTTextGenerator.Infrastructure</Title>
	<Authors>InanisPluvia</Authors>
	<PackageOutputPath>C:\Users\LordVT\Desktop\FinalQualifyingWork\src\csharp\NugetRepo</PackageOutputPath>
	<Version>1.1.18</Version>
	<Nullable>enable</Nullable>
	<TargetFramework>net8.0</TargetFramework>
      <GeneratePackageOnBuild>false</GeneratePackageOnBuild>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="AllMiniLmL6V2Sharp" Version="0.0.3" />
    <PackageReference Include="FastBertTokenizer" Version="1.1.30-alpha" />
    <PackageReference Include="LLamaSharp" Version="0.26.0" />
    <PackageReference Include="LLamaSharp.Backend.Cpu" Version="0.26.0" />
    <PackageReference Include="LLamaSharp.Backend.Cuda11.Windows" Version="0.24.0" />
    <PackageReference Include="LLamaSharp.semantic-kernel" Version="0.26.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.17" />
    <PackageReference Include="Microsoft.ML" Version="5.0.0" />
    <PackageReference Include="Microsoft.ML.OnnxRuntime" Version="1.23.2" />
    <PackageReference Include="Microsoft.ML.OnnxRuntime.Managed" Version="1.24.3" />
    <PackageReference Include="Microsoft.ML.OnnxTransformer" Version="3.0.1" />
    <PackageReference Include="Microsoft.VisualStudio.Threading" Version="17.14.15" />
    <PackageReference Include="Mosaik.Core" Version="25.10.62118" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.5-beta1" />
    <PackageReference Include="Qdrant.Client" Version="1.17.0" />
    <PackageReference Include="RestSharp" Version="114.0.0" />
    <PackageReference Include="SentenceTransformers" Version="25.6.59118" />
    <PackageReference Include="SentenceTransformers.MiniLM" Version="25.6.59118" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\TextGenerator.Core\TextGenerator.Core.csproj" />
  </ItemGroup>

  <ItemGroup Condition="'$(TargetFramework)' == 'net8.0'">
    <PackageReference Include="LLamaSharp.Jinja.Executors" Version="1.0.0" />
    <PackageReference Include="Neo4j.Driver" Version="6.0.0" />
  </ItemGroup>

  <ItemGroup>
    <Folder Include="Narrative\" />
  </ItemGroup>

    <ItemGroup>
        <Content Include="..\models\**\*">
            <Link>models\%(RecursiveDir)%(Filename)%(Extension)</Link>
            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </Content>
    </ItemGroup>

</Project>
```


## TextGenerator.Service\Controllers\DialogueController.cs

```cs
using Microsoft.AspNetCore.Mvc;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DialogueController : ControllerBase
{
    private readonly INarrativeAgent _agent;

    public DialogueController(INarrativeAgent agent) => _agent = agent;
    
    /// <summary>
    /// Начало диалога: генерация корневой фразы NPC и вариантов ответов (depth=1 по умолчанию)
    /// </summary>
    [HttpPost("start")]
    public async Task<ActionResult<DialogueNode>> StartDialogue([FromBody] StartDialogueRequest request)
    {
        var result = await _agent.GenerateDialogue(
            request.Npc,
            request.Player,
            request.Variety);
        return Ok(result);
    }
    
    /// <summary>
    /// Продолжение диалога: на основе выбранного игроком узла генерируются следующие варианты (stepped mode, depth=1)
    /// </summary>
    [HttpPost("continue")]
    public async Task<ActionResult<DialogueNode>> ContinueDialogue([FromBody] ContinueDialogueRequest request)
    {
        var result = await _agent.GenerateDialogue(
            request.Npc,
            request.Player,
            request.ChosenNode,
            request.Variety);
        return Ok(result);
    }
    
    /// <summary>
    /// Генерация полного дерева диалога заданной глубины (depth > 1)
    /// </summary>
    [HttpPost("generate-full")]
    public async Task<ActionResult<DialogueNode>> GenerateFullDialogue([FromBody] FullDialogueRequest request)
    {
        if (request.Depth <= 1)
            return BadRequest("Для полного дерева глубина должна быть больше 1.");

        var result = await _agent.GenerateDialogue(
            request.Npc,
            request.Player,
            request.Depth,
            request.Variety);
        return Ok(result);
    }

    /// <summary>
    /// Универсальный метод, покрывающий все варианты (совместимость со старым API)
    /// </summary>
    [HttpPost("generate")]
    public async Task<ActionResult<DialogueNode>> GenerateDialogue([FromBody] UniversalDialogueRequest request)
    {
        DialogueNode result;

        // Если передан parentNode – продолжаем диалог (stepped)
        if (request.ParentNode != null)
        {
            result = await _agent.GenerateDialogue(
                request.Npc,
                request.Player,
                request.ParentNode,
                request.Variety);
        }
        // Иначе если указана глубина (и она > 1) – генерируем полное дерево
        else if (request.Depth > 1)
        {
            result = await _agent.GenerateDialogue(
                request.Npc,
                request.Player,
                request.Depth,
                request.Variety);
        }
        // Иначе – начало диалога с depth=1 (варианты)
        else
        {
            result = await _agent.GenerateDialogue(
                request.Npc,
                request.Player,
                request.Variety);
        }

        return Ok(result);
    }


    #region Request DTOs

    public class StartDialogueRequest
    {
        public SmartNPC Npc { get; set; }
        public Player Player { get; set; }
        public int Variety { get; set; } = 3;
    }

    public class ContinueDialogueRequest
    {
        public SmartNPC Npc { get; set; }
        public Player Player { get; set; }
        public DialogueNode ChosenNode { get; set; }
        public int Variety { get; set; } = 3;
    }

    public class FullDialogueRequest
    {
        public SmartNPC Npc { get; set; }
        public Player Player { get; set; }
        public int Depth { get; set; }
        public int Variety { get; set; } = 3;
    }

    public class UniversalDialogueRequest
    {
        public SmartNPC Npc { get; set; }
        public Player Player { get; set; }
        public DialogueNode? ParentNode { get; set; }
        public int? Depth { get; set; }
        public int Variety { get; set; } = 3;
    }

    #endregion
}
```


## TextGenerator.Service\Controllers\QuestController.cs

```cs
using Microsoft.AspNetCore.Mvc;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Models.Actors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactions.Quests;

namespace TextGenerator.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestController : ControllerBase
{
    private readonly INarrativeAgent _agent;

    public QuestController(INarrativeAgent agent) => _agent = agent;

    [HttpPost("generate")]
    public async Task<ActionResult<Quest>> GenerateQuest([FromBody] QuestRequest request)
    {
        var quest = await _agent.GenerateQuest(request.Npc, request.Player, request.GoalDescription);
        return Ok(quest);
    }

    public class QuestRequest
    {
        public SmartNPC Npc { get; set; }
        public Player Player { get; set; }
        public string GoalDescription { get; set; }
    }
}
```


## TextGenerator.Service\GPTTextGenerator.Service.http

```http
@GPTTextGenerator.Service_HostAddress = http://localhost:5208

GET {{GPTTextGenerator.Service_HostAddress}}/weatherforecast/
Accept: application/json

###
```


## TextGenerator.Service\Program.cs

```cs
using Microsoft.VisualStudio.Threading;
using TextGenerator.Core.Interfaces.Cache;
using TextGenerator.Core.Interfaces.EdgeAI;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Interfaces.RAG;
using TextGenerator.Infrastructure.Caching;
using TextGenerator.Infrastructure.EdgeAI;
using TextGenerator.Infrastructure.Memory;
using TextGenerator.Infrastructure.Narrative.Agents;
using TextGenerator.Infrastructure.Narrative.Environment;
using TextGenerator.Infrastructure.Processors;
using TextGenerator.Infrastructure.RAG;
//using TextGenerator.Infrastructure.Reward;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<JoinableTaskContext>();

// 1. Конфигурация локальной LLM
builder.Services.Configure<LLamaSharpOptions>(builder.Configuration.GetSection("LLama"));
builder.Services.AddSingleton<ILLMClient, LocalLLMClient>();

// 2. Компоненты памяти и RAG
builder.Services.AddSingleton<IEmbeddingGenerator, EmbeddingGeneratorService>();
builder.Services.AddSingleton<IVectorMemoryStore, QdrantVectorMemoryStore>(); // требуется Qdrant.Client
builder.Services.AddScoped<IRAGService, RAGService>();
builder.Services.AddScoped<ITextSummarizer, TextSummarizer>();
builder.Services.AddScoped<IDialogueCache, DialogueCache>();
builder.Services.AddMemoryCache(); // IMemoryCache

// 3. Narrative Environment
builder.Services.AddSingleton<INarrativeEnvironment, NarrativeEnvironmentService>();

// 4. LLM prompt builder and response parser
builder.Services.AddScoped<ILLMPromptBuilder, LLMPromptBuilder>();
builder.Services.AddScoped<ILLMResponseParser, LLMResponseParser>();

// 5. Обновлённые пре/постпроцессоры
builder.Services.AddScoped<IPreprocessor, PreprocessorService>();
builder.Services.AddScoped<IPostprocessor, PostprocessorService>();

// 6. Система наград и метрик
//builder.Services.AddSingleton<IDialogueValidator, DialogueValidator>(); // если модель ONNX доступна
//builder.Services.AddSingleton<IRewardCalculator, RewardCalculator>();
//builder.Services.AddSingleton<IFeedbackCollector, FeedbackCollector>();
//builder.Services.AddSingleton<IModelFineTuner, ModelFineTuner>();

// 7. Нарративный контекст
builder.Services.AddScoped<INarrativeAgent, NarrativeAgent>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
```


## TextGenerator.Service\TextGenerator.Service.csproj

```csproj
<Project Sdk="Microsoft.NET.Sdk.Web">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <Nullable>enable</Nullable>
        <ImplicitUsings>enable</ImplicitUsings>
        <LangVersion>latest</LangVersion>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.25"/>
        <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2"/>
    </ItemGroup>

    <ItemGroup>
      <ProjectReference Include="..\TextGenerator.Infrastructure\TextGenerator.Infrastructure.csproj" />
    </ItemGroup>

    <ItemGroup>
        <Content Include="..\models\**\*">
            <Link>models\%(RecursiveDir)%(Filename)%(Extension)</Link>
            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </Content>
    </ItemGroup>

</Project>
```

