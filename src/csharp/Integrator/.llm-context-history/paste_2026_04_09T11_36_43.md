## File Tree @ 2026-04-07 17:27:37
```
├── Integrator.sln
├── TextGenerator.Core/
│   ├── Common/
│   │   ├── Enums/
│   │   │   ├── ItemType.cs
│   │   │   ├── StatType.cs
│   │   │   └── Status.cs
│   │   └── IEntity.cs
│   ├── Interfaces/
│   │   ├── Cache/
│   │   │   └── IDialogueCache.cs
│   │   ├── EdgeAI/
│   │   │   └── ILLMClient.cs
│   │   ├── Memory/
│   │   │   ├── IMemory.cs
│   │   │   ├── IRewardCalculator.cs
│   │   │   ├── IRewardCollector.cs
│   │   │   ├── ISummarizer.cs
│   │   │   └── IVectorMemory.cs
│   │   ├── Narrative/
│   │   │   ├── INarrativeAgent.cs
│   │   │   └── INarrativeEnvironment.cs
│   │   ├── Processors/
│   │   │   ├── IAnalyzer.cs
│   │   │   ├── IPostprocessor.cs
│   │   │   └── IPreprocessor.cs
│   │   ├── RAG/
│   │   │   └── IRAGService.cs
│   │   └── RL/
│   │       └── IRLFineTuner.cs
│   ├── Models/
│   │   ├── Actions/
│   │   │   ├── GameAction.cs
│   │   │   ├── GameReaction.cs
│   │   │   ├── Requirement.cs
│   │   │   └── SocialConnection.cs
│   │   ├── Feedback/
│   │   │   └── InteractionFeedback.cs
│   │   ├── Interactions/
│   │   │   ├── DialogueEntry.cs
│   │   │   ├── DialogueNode.cs
│   │   │   ├── Quest.cs
│   │   │   └── QuestChain.cs
│   │   ├── Interactors/
│   │   │   ├── GameEnvironment.cs
│   │   │   ├── Player.cs
│   │   │   ├── SmartNPC.cs
│   │   │   └── WorldContext.cs
│   │   ├── Metrics/
│   │   │   └── PersonalizationMetrics.cs
│   │   ├── Objects/
│   │   │   ├── Inventory.cs
│   │   │   ├── Item.cs
│   │   │   └── Reward.cs
│   │   └── World/
│   │       ├── GameObject.cs
│   │       └── Stat.cs
│   └── TextGenerator.Core.csproj
├── TextGenerator.Infrastructure/
│   ├── Agents/
│   │   └── NarrativeAgent.cs
│   ├── Analyzer/
│   │   └── DialogueAnalyzer.cs
│   ├── Caching/
│   │   └── DialogueCache.cs
│   ├── EdgeAI/
│   │   ├── LocalLLMClient.cs
│   │   └── ModelDownloader.cs
│   ├── Extensions/
│   │   └── DialogueExtensions.cs
│   ├── Memory/
│   │   ├── QdrantMemory.cs
│   │   ├── Summarizer.cs
│   │   └── VectorMemoryService.cs
│   ├── RL/
│   │   └── RLFineTuner.cs
│   ├── Reward/
│   │   ├── RewardCalculator.cs
│   │   └── RewardCollector.cs
│   ├── Services/
│   │   ├── NarrativeEnvironmentService.cs
│   │   ├── Processors/
│   │   │   ├── PostprocessorService.cs
│   │   │   └── PreprocessorService.cs
│   │   └── RAG/
│   │       └── RAGService.cs
│   └── TextGenerator.Infrastructure.csproj
└── TextGenerator.Service/
    ├── Controllers/
    │   ├── DialogueController.cs
    │   └── QuestController.cs
    ├── GPTTextGenerator.Service.http
    ├── Program.cs
    ├── Properties/
    │   └── launchSettings.json
    ├── TextGenerator.Service.csproj
    ├── appsettings.Development.json
    └── appsettings.json
```

## File Analysis @ 2026-04-07 17:27:37
- Total files: 64
- .cs: 56
- .csproj: 3
- .http: 1
- .json: 3
- .sln: 1


---
#### Integrator.sln @ 2026-04-07 17:27:37
```
﻿
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.3.32825.248
MinimumVisualStudioVersion = 10.0.40219.1
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "MainPlugin", "MainPlugin", "{26A94222-023E-4635-AF04-B739FA802E42}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "TextGenerator.Core", "TextGenerator.Core\TextGenerator.Core.csproj", "{D173E85B-DA14-4806-97AE-15A96228B379}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "TextGenerator.Infrastructure", "TextGenerator.Infrastructure\TextGenerator.Infrastructure.csproj", "{DB47C8B4-E836-408C-A84D-8ECED0BA9DAA}"
ProjectSection(ProjectDependencies) = postProject
{D173E85B-DA14-4806-97AE-15A96228B379} = {D173E85B-DA14-4806-97AE-15A96228B379}
EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "TextGenerator.Service", "TextGenerator.Service\TextGenerator.Service.csproj", "{596C08C7-3BBC-4ADB-8641-9E441F11E893}"
EndProject
Global
GlobalSection(SolutionConfigurationPlatforms) = preSolution
Debug|Any CPU = Debug|Any CPU
Release|Any CPU = Release|Any CPU
EndGlobalSection
GlobalSection(ProjectConfigurationPlatforms) = postSolution
{88794C3E-E34D-48C0-9422-895FD27FBBB3}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
{88794C3E-E34D-48C0-9422-895FD27FBBB3}.Debug|Any CPU.Build.0 = Debug|Any CPU
{88794C3E-E34D-48C0-9422-895FD27FBBB3}.Release|Any CPU.ActiveCfg = Release|Any CPU
{D173E85B-DA14-4806-97AE-15A96228B379}.Debug|Any CPU.ActiveCfg = Release|Any CPU
{D173E85B-DA14-4806-97AE-15A96228B379}.Debug|Any CPU.Build.0 = Release|Any CPU
{D173E85B-DA14-4806-97AE-15A96228B379}.Release|Any CPU.ActiveCfg = Release|Any CPU
{D173E85B-DA14-4806-97AE-15A96228B379}.Release|Any CPU.Build.0 = Release|Any CPU
{DB47C8B4-E836-408C-A84D-8ECED0BA9DAA}.Debug|Any CPU.ActiveCfg = Release|Any CPU
{DB47C8B4-E836-408C-A84D-8ECED0BA9DAA}.Debug|Any CPU.Build.0 = Release|Any CPU
{DB47C8B4-E836-408C-A84D-8ECED0BA9DAA}.Release|Any CPU.ActiveCfg = Release|Any CPU
{DB47C8B4-E836-408C-A84D-8ECED0BA9DAA}.Release|Any CPU.Build.0 = Release|Any CPU
{596C08C7-3BBC-4ADB-8641-9E441F11E893}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
{596C08C7-3BBC-4ADB-8641-9E441F11E893}.Debug|Any CPU.Build.0 = Debug|Any CPU
{596C08C7-3BBC-4ADB-8641-9E441F11E893}.Release|Any CPU.ActiveCfg = Release|Any CPU
{596C08C7-3BBC-4ADB-8641-9E441F11E893}.Release|Any CPU.Build.0 = Release|Any CPU
EndGlobalSection
GlobalSection(SolutionProperties) = preSolution
HideSolutionNode = FALSE
EndGlobalSection
GlobalSection(NestedProjects) = preSolution
{88794C3E-E34D-48C0-9422-895FD27FBBB3} = {E7EF6865-5988-47C9-9C18-0E4C523DA63F}
{D173E85B-DA14-4806-97AE-15A96228B379} = {26A94222-023E-4635-AF04-B739FA802E42}
{DB47C8B4-E836-408C-A84D-8ECED0BA9DAA} = {26A94222-023E-4635-AF04-B739FA802E42}
EndGlobalSection
GlobalSection(ExtensibilityGlobals) = postSolution
SolutionGuid = {2ED44C03-75E3-4593-B76A-C8887E6E4F8F}
EndGlobalSection
EndGlobal

```

---
#### TextGenerator.Core/Common/Enums/ItemType.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Common.Enums
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

---
#### TextGenerator.Core/Common/Enums/StatType.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Common.Enums
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

---
#### TextGenerator.Core/Common/Enums/Status.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Common.Enums
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

---
#### TextGenerator.Core/Common/IEntity.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Common
{
    public interface IEntity
    {
        public int Id { get; }
    }
}

```

---
#### TextGenerator.Core/Interfaces/Cache/IDialogueCache.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Cache;

public interface IDialogueCache
{
    bool TryGet(string key, out DialogueEntry entry);
    void Set(string key, DialogueEntry entry, TimeSpan? ttl = null);
    string MakeKey(SmartNPC npc, Player player, string playerInput, string contextHash);
}
```

---
#### TextGenerator.Core/Interfaces/EdgeAI/ILLMClient.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Interfaces.EdgeAI;

public interface ILLMClient
{
    Task<string> GenerateAsync(string prompt, int maxTokens = 256, float temperature = 0.7f);
}
```

---
#### TextGenerator.Core/Interfaces/Memory/IMemory.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Interfaces.Memory;

public interface IMemory
{
    Task AddMemory(string text, float[] embedding, string metadata);
    Task<List<(string Text, float Score)>> RetrieveRelevant(string query, float[] queryEmbedding, int topK = 5);

    Task<List<(string Text, float Score, DateTime Timestamp)>> RetrieveRelevantWithTimestamp(string query,
        float[] queryEmbedding, int topK);
}
```

---
#### TextGenerator.Core/Interfaces/Memory/IRewardCalculator.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Interfaces.Memory;

public interface IRewardCalculator
{
    float CalculateReward(string generatedText, string context, string expectedStyle);
}
```

---
#### TextGenerator.Core/Interfaces/Memory/IRewardCollector.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Models.Feedback;

namespace TextGenerator.Core.Interfaces.Memory;

public interface IRewardCollector
{
    void RecordFeedback(InteractionFeedback feedback);
    Task<List<InteractionFeedback>> GetDatasetAsync();
    Task SaveToDatasetAsync(string path);
}
```

---
#### TextGenerator.Core/Interfaces/Memory/ISummarizer.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Interfaces.Memory;

public interface ISummarizer
{
    Task<string> Summarize(string longText);
}
```

---
#### TextGenerator.Core/Interfaces/Memory/IVectorMemory.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Interfaces.Memory;

public interface IVectorMemory
{
    float[] GetEmbedding(string text);
}
```

---
#### TextGenerator.Core/Interfaces/Narrative/INarrativeAgent.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Narrative;

public interface INarrativeAgent
{
    Task<DialogueEntry> GenerateDialogue(SmartNPC npc, Player player, string playerInput, int depth, int variety);
    Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription);
}
```

---
#### TextGenerator.Core/Interfaces/Narrative/INarrativeEnvironment.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Narrative;

public interface INarrativeEnvironment
{
    Task<WorldContext> GetRelevantContext(SmartNPC npc, Player player, string currentInput);
    Task UpdateState(string entityId, string property, object value);
    Task<IEnumerable<SocialConnection>> GetRelationships(int npcId);
    Task LogInteraction(string description, DateTime timestamp);
}
```

---
#### TextGenerator.Core/Interfaces/Processors/IAnalyzer.cs @ 2026-04-07 17:27:37
```
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator.Core.Interfaces.Processors
{
    public interface IAnalyzer
    {
        public bool CheckCorrections(List<string> dialogueBranches);
    }
}

```

---
#### TextGenerator.Core/Interfaces/Processors/IPostprocessor.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Processors
{
    public interface IPostprocessor
    {
        DialogueEntry DecodeAPIBranchedDialogueResponse(SmartNPC npc, string response);
        DialogueNode DecodeSingleStepDialogueResponse(SmartNPC npc, string response);

        Quest ParseQuest(string response);
        //Quest ParseQuest();
        //bool CheckСorrectness(); // планирую написать нейронку с подкреплением на python подключу с IronPython
    }
}

```

---
#### TextGenerator.Core/Interfaces/Processors/IPreprocessor.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Processors
{
    public interface IPreprocessor
    {
        string GenerateBasicBranchedDialogueRequest(SmartNPC npc, int depth, int variety);
        string GenerateQuestPrompt(SmartNPC npc, Player player, string goalDescription);
        string GenerateBasicSteppedDialogueRequest(SmartNPC npc, DialogueNode prevNode, int variety, WorldContext context);
    }
}

```

---
#### TextGenerator.Core/Interfaces/RAG/IRAGService.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Interfaces.RAG;

public interface IRAGService
{
    Task<string> AugmentPrompt(string userQuery, string basePrompt);
    Task StoreInteraction(string text, string metadata);
}
```

---
#### TextGenerator.Core/Interfaces/RL/IRLFineTuner.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Interfaces.RL;

public interface IRLFineTuner
{
    Task RunPeriodicFineTuningAsync();
}
```

---
#### TextGenerator.Core/Models/Actions/GameAction.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Actions
{
    public class GameAction : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Actions/GameReaction.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Actions
{
    public class GameReaction : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Actions/Requirement.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;

namespace TextGenerator.Core.Models.Actions
{
    public class Requirement : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Actions/SocialConnection.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Models.Actions
{
    public class SocialConnection : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public SmartNPC RelatedNPC { get; set; }

        public string Type { get; set; }
        public string Relationships { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Feedback/InteractionFeedback.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;

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
    public int Id { get; }
}
```

---
#### TextGenerator.Core/Models/Interactions/DialogueEntry.cs @ 2026-04-07 17:27:37
```
﻿using System.Collections.Generic;
using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Interactions
{
    public class DialogueEntry : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Text { get; set; }

        public List<DialogueNode> Childs { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Interactions/DialogueNode.cs @ 2026-04-07 17:27:37
```
﻿using System.Collections.Generic;
using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Interactions
{
    public class DialogueNode : IEntity
    {
        public int Id => ID;
        public int ID { get; set; }
        public string InterlocutorNPC { get; set; }
        public string InterlocutorPlayer { get; set; }
        public string Name { get; set; }
        public string NPCText { get; set; }
        public string PlayerText { get; set; }
        public List<DialogueNode> Childs { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Interactions/Quest.cs @ 2026-04-07 17:27:37
```
﻿using System.Collections.Generic;
using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Objects;

namespace TextGenerator.Core.Models.Interactions
{
    public class Quest : IEntity
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

```

---
#### TextGenerator.Core/Models/Interactions/QuestChain.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Interactions
{
    public class QuestChain : IEntity
    {
        public int Id => ChainQuestId;
        public int ChainQuestId { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Interactors/GameEnvironment.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Models.Interactors;
using System.Collections.Generic;
using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.World;

namespace TextGenerator.Core.Models.Interactors
{
    public class GameEnvironment : IEntity
    {
        public int Id => EnvironmentId;
        public int EnvironmentId { get; set; }
        public IEnumerable<SmartNPC> SmartNPCs { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<GameObject> Objects { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Interactors/Player.cs @ 2026-04-07 17:27:37
```
﻿using System.Numerics;
using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Objects;

namespace TextGenerator.Core.Models.Interactors
{
    public class Player : IEntity
    {
        public int Id => ID;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Vector3 Position { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public Inventory Inventory { get; set; }
        public List<DialogueEntry> Dialogues { get; set; }
        public List<GameReaction> Reactions { get; set; }
        public List<GameAction> Actions { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Interactors/SmartNPC.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactions;

namespace TextGenerator.Core.Models.Interactors
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

```

---
#### TextGenerator.Core/Models/Interactors/WorldContext.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Models.Interactors;

public class WorldContext
{
    public string LocationDescription { get; set; }
    public List<string> RecentEvents { get; set; }
    public Dictionary<string, string> EntityStates { get; set; }
    public float TimeOfDay { get; set; }
}
```

---
#### TextGenerator.Core/Models/Metrics/PersonalizationMetrics.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Core.Models.Metrics;

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

---
#### TextGenerator.Core/Models/Objects/Inventory.cs @ 2026-04-07 17:27:37
```
﻿using System.Collections.Generic;
using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Objects
{
    public class Inventory : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public int OwnerID { get; set; } // Ссылка на владельца инвентаря
        public List<Item> Items { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Objects/Item.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Objects
{
    public class Item : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Objects/Reward.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Objects
{
    public class Reward : IEntity
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public Item RelatedItem { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/World/GameObject.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;

namespace TextGenerator.Core.Models.World
{
    public class GameObject : IEntity
    {
        public int Id => PObjectId;
        public int PObjectId { get; set; }
        public IEnumerable<Stat>? Stats { get; set; }
        public ItemType PObjectType { get; set; }
        public string History { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/World/Stat.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Common;
using TextGenerator.Core.Common.Enums;

namespace TextGenerator.Core.Models.World
{
    public class Stat : IEntity
    {
        public int Id => StatId;
        public int StatId { get; set; }
        public StatType StatType { get; set; }
        public float Value { get; set; }
    }
}

```

---
#### TextGenerator.Core/TextGenerator.Core.csproj @ 2026-04-07 17:27:37
```
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.1</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
<LangVersion>10.0</LangVersion>
<GeneratePackageOnBuild>true</GeneratePackageOnBuild>
<PackageId>gpt-text-generator-entities</PackageId>
<Title>GPTTextGenerator.Entites</Title>
<Authors>InanisPluvia</Authors>
<PackageOutputPath>C:\Users\LordVT\Desktop\FinalQualifyingWork\src\csharp\NugetRepo</PackageOutputPath>
<Version>1.1.18</Version>
  </PropertyGroup>

</Project>

```

---
#### TextGenerator.Infrastructure/Agents/NarrativeAgent.cs @ 2026-04-07 17:27:37
```
﻿using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using TextGenerator.Core.Interfaces.EdgeAI;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Interfaces.RAG;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Infrastructure.Agents;

    public class NarrativeAgent : INarrativeAgent
    {
        private readonly ILLMClient _llm;
        private readonly IPreprocessor _preprocessor;
        private readonly IPostprocessor _postprocessor;
        private readonly IRAGService _rag;
        private readonly IRewardCalculator _reward;
        private readonly ISummarizer _summarizer;
        private readonly IMemoryCache _cache;
        private readonly INarrativeEnvironment _narrativeEnv;
        
        // Храним последний узел диалога для каждой пары (NPC, Player)
        private readonly ConcurrentDictionary<(int npcId, int playerId), DialogueNode> _lastNode = new();

        public NarrativeAgent(ILLMClient llm, IPreprocessor preprocessor, IPostprocessor postprocessor,
            IRAGService rag, IRewardCalculator reward, ISummarizer summarizer, IMemoryCache cache, INarrativeEnvironment narrativeEnv)
        {
            _llm = llm;
            _preprocessor = preprocessor;
            _postprocessor = postprocessor;
            _rag = rag;
            _reward = reward;
            _summarizer = summarizer;
            _cache = cache;
            _narrativeEnv = narrativeEnv;
        }

        public async Task<DialogueEntry> GenerateDialogue(SmartNPC npc, Player player, string playerInput, int depth, int variety)
        {
            var key = (npc.Id, player.Id);
            _lastNode.TryGetValue(key, out var lastNode);
            
            // 1. Проверка кэша
            string cacheKey = $"{npc.Id}_{player.Id}_{playerInput.GetHashCode()}";
            if (_cache.TryGetValue(cacheKey, out DialogueEntry cached))
                return cached;

            // 2. Получение релевантного контекста из NarrativeEnvironment
            var context = await _narrativeEnv.GetRelevantContext(npc, player, playerInput);

            // 3. Формирование промпта для следующего шага (stepped)
            string prompt = _preprocessor.GenerateBasicSteppedDialogueRequest(npc, lastNode, variety, context);

            // 4. RAG-усиление
            var augmentedPrompt = await _rag.AugmentPrompt(playerInput, prompt);

            // 5. Генерация через локальную LLM
            string rawResponse = await _llm.GenerateAsync(augmentedPrompt, maxTokens: 256);

            // 6. Постобработка – получаем только следующий узел диалога
            var nextNode = _postprocessor.DecodeSingleStepDialogueResponse(npc, rawResponse);
            var entry = new DialogueEntry { Text = nextNode.NPCText, Childs = new List<DialogueNode> { nextNode } };

            // 7. Сохраняем в кэш
            _cache.Set(cacheKey, entry, TimeSpan.FromMinutes(10));

            // 8. Сохраняем в память (RAG)
            await _rag.StoreInteraction($"NPC:{npc.Name} сказал: {nextNode.NPCText}", $"playerInput={playerInput}");
    
            _lastNode[key] = nextNode; // для следующего шага
            return entry;
        }

        public async Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription)
        {
            var prompt = _preprocessor.GenerateQuestPrompt(npc, player, goalDescription); // новый метод в PreprocessorService
            var rawQuest = await _llm.GenerateAsync(prompt);
            var quest = _postprocessor.ParseQuest(rawQuest);
            await _rag.StoreInteraction($"Сгенерирован квест: {quest.Name}", $"NPC={npc.Name}");
            return quest;
        }
    }
```

---
#### TextGenerator.Infrastructure/Analyzer/DialogueAnalyzer.cs @ 2026-04-07 17:27:37
```
﻿//using BERTTokenizers;
using FastBertTokenizer;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using TextGenerator.Core.Interfaces.Processors;

namespace TextGenerator.Infrastructure.Analyzer
{
    public struct BertInput
    {
        public long[] InputIds { get; set; }
        public long[] AttentionMask { get; set; }
        public long[] TypeIds { get; set; }
    }

    public class DialogueAnalyzer : IAnalyzer
    {
        private static BertTokenizer tokenizer;
        private InferenceSession _onnxSession;

        public DialogueAnalyzer()
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
}


```

---
#### TextGenerator.Infrastructure/Caching/DialogueCache.cs @ 2026-04-07 17:27:37
```
﻿using Microsoft.Extensions.Caching.Memory;
using TextGenerator.Core.Interfaces.Cache;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Infrastructure.Caching;

public class DialogueCache : IDialogueCache
{
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _defaultTtl = TimeSpan.FromMinutes(15);
    
    public DialogueCache(IMemoryCache cache) => _cache = cache;
    
    public bool TryGet(string key, out DialogueEntry entry) => _cache.TryGetValue(key, out entry);
    public void Set(string key, DialogueEntry entry, TimeSpan? ttl = null) 
        => _cache.Set(key, entry, ttl ?? _defaultTtl);
    
    public string MakeKey(SmartNPC npc, Player player, string playerInput, string contextHash)
        => $"dial_{npc.Id}_{player.Id}_{playerInput.GetHashCode()}_{contextHash}";
}
```

---
#### TextGenerator.Infrastructure/EdgeAI/LocalLLMClient.cs @ 2026-04-07 17:27:37
```
﻿using LLama;
using LLama.Common;
using Microsoft.Extensions.Options;
using System.Text;
using LLama.Sampling;
using TextGenerator.Core.Interfaces.EdgeAI;

namespace TextGenerator.Infrastructure.EdgeAI;

public class LocalLLMClient : ILLMClient
{
    private readonly Lazy<Task<InteractiveExecutor>> _executor;
    private readonly LLamaContext _context;

    public LocalLLMClient(IOptions<LLamaSharpOptions> options)
    {
        _executor = new Lazy<Task<InteractiveExecutor>>(() => LoadModelAsync(options.Value.ModelPath));
    }
    
    private async Task<InteractiveExecutor> LoadModelAsync(string modelPath)
    {
        var parameters = new ModelParams(modelPath)
        {
            ContextSize = 2048,
            GpuLayerCount = 20,   // использовать GPU
            BatchSize = 512
        };
        var model = await Task.Run(() => LLamaWeights.LoadFromFile(parameters));
        var context = model.CreateContext(parameters);
        return new InteractiveExecutor(context);
    }

    public async Task<string> GenerateAsync(string prompt, int maxTokens = 256, float temperature = 0.7f)
    {
        var executor = await _executor.Value;
        
        var inferenceParams = new InferenceParams
        {
            MaxTokens = maxTokens,
            AntiPrompts = new[] { "\nИгрок:", "\nNPC:" },
            SamplingPipeline = new DefaultSamplingPipeline
            {
                Temperature = temperature
            }
        };

        var result = new StringBuilder();

        await foreach (var token in executor.InferAsync(prompt, inferenceParams))
        {
            result.Append(token);
        }

        return result.ToString();
    }
}

public class LLamaSharpOptions
{
    public string ModelPath { get; set; } = "models/llama-3-8b-q4.gguf";
}
```

---
#### TextGenerator.Infrastructure/EdgeAI/ModelDownloader.cs @ 2026-04-07 17:27:37
```
﻿namespace TextGenerator.Infrastructure.EdgeAI;

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

---
#### TextGenerator.Infrastructure/Extensions/DialogueExtensions.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextGenerator.Infrastructure.Extensions
{
    public static class DialogueExtensions
    {
        public static void AddChildToEntry(this DialogueEntry entry, DialogueNode node)
        {
            entry.Childs ??= new List<DialogueNode>();

            if (!entry.Childs.Contains(node))
            {
                entry.Childs.Add(node);
            }
        }

        public static void AddChildToNode(this DialogueNode parent, DialogueNode child)
        {
            parent.Childs ??= new List<DialogueNode>();

            if (!parent.Childs.Contains(child))
            {
                parent.Childs.Add(child);
            }
        }

        public static DialogueNode GetDialogueNodeByName(this DialogueEntry dialogueEntry, string name)
        {
            if (dialogueEntry == null)
            {
                throw new ArgumentNullException("dialogueEntry cannot be null.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name cannot be null or empty.");
            }

            return dialogueEntry.GetDialogueNodeByNameRecursive(name, 0);
        }

        private static DialogueNode GetDialogueNodeByNameRecursive(this DialogueEntry dialogueEntry, string name, int currentLevel)
        {
            if (dialogueEntry == null)
            {
                return null;
            }

            int nextLevel = currentLevel + 1;
            string pattern = @"(?<variant>\d(\.\d){" + currentLevel + "})";
            Regex regex = new(pattern);

            foreach (var child in dialogueEntry.Childs)
            {
                Match match = regex.Match(child.Name);
                if (match.Success && match.Value == name[..(currentLevel * 2 + 1)])
                {
                    if (nextLevel == name.Split('.').Length)
                    {
                        return child;
                    }
                    else
                    {
                        DialogueEntry childEntry = new() { Childs = child.Childs };
                        return childEntry.GetDialogueNodeByNameRecursive(name, nextLevel);
                    }
                }
            }

            return null;
        }
    }
}

```

---
#### TextGenerator.Infrastructure/Memory/QdrantMemory.cs @ 2026-04-07 17:27:37
```
﻿using Google.Protobuf.Collections;
using Qdrant.Client;
using Qdrant.Client.Grpc;
using TextGenerator.Core.Interfaces.Memory;

namespace TextGenerator.Infrastructure.Memory;

    public class QdrantMemory : IMemory
    {
        private readonly QdrantClient _client;
        private const string CollectionName = "game_memories";

        public QdrantMemory(string host = "localhost", int port = 6333)
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
                    ["timestamp"] = DateTime.UtcNow.Ticks   // добавлено
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

---
#### TextGenerator.Infrastructure/Memory/Summarizer.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Infrastructure.EdgeAI;

namespace TextGenerator.Infrastructure.Memory;

public class Summarizer : ISummarizer
{
    private readonly LocalLLMClient _llm;

    public Summarizer(LocalLLMClient llm) => _llm = llm;

    public async Task<string> Summarize(string longText)
    {
        var prompt = $"Кратко перескажи следующий диалог или событие (не более 2 предложений):\n{longText}";
        return await _llm.GenerateAsync(prompt, maxTokens: 100);
    }
}
```

---
#### TextGenerator.Infrastructure/Memory/VectorMemoryService.cs @ 2026-04-07 17:27:37
```
﻿using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using TextGenerator.Core.Interfaces.Memory;

namespace TextGenerator.Infrastructure.Memory;

public class VectorMemoryService : IVectorMemory
{
    private readonly InferenceSession _embeddingSession;

    public VectorMemoryService(string embeddingModelPath = "all-MiniLM-L6-v2.onnx")
    {
        _embeddingSession = new InferenceSession(embeddingModelPath);
    }

    public float[] GetEmbedding(string text)
    {
        var tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Take(128).ToArray();
        var input = string.Join(" ", tokens);
        var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input_ids",
                new DenseTensor<long>(new long[] { 1, input.Length }, new[] { 1, input.Length }))
        };
        using var results = _embeddingSession.Run(inputs);
        var embedding = results.First().AsTensor<float>().ToArray();
        return embedding;
    }
}
```

---
#### TextGenerator.Infrastructure/RL/RLFineTuner.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Interfaces.EdgeAI;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.RL;

namespace TextGenerator.Infrastructure.RL;

public class RLFineTuner : IRLFineTuner
{
    private readonly IRewardCollector _collector;
    private readonly ILLMClient _llm;
    
    public RLFineTuner(IRewardCollector collector, ILLMClient llm)
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

---
#### TextGenerator.Infrastructure/Reward/RewardCalculator.cs @ 2026-04-07 17:27:37
```
﻿using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Processors;

namespace TextGenerator.Infrastructure.Reward;

public class RewardCalculator : IRewardCalculator
{
    private readonly IAnalyzer _dialogueAnalyzer;

    public RewardCalculator(IAnalyzer dialogueAnalyzer) => _dialogueAnalyzer = dialogueAnalyzer;

    public float CalculateReward(string generatedText, string context, string expectedStyle)
    {
        // 1. Синтаксическая корректность (0-1)
        float syntaxScore = _dialogueAnalyzer.CheckCorrections(new List<string> { generatedText }) ? 1.0f : 0.3f;

        // 2. Семантическая согласованность (упрощённо: проверка наличия ключевых слов контекста)
        float contextScore = context.Contains(generatedText[..Math.Min(50, generatedText.Length)]) ? 0.8f : 0.5f;

        // 3. Стилистическое соответствие (имитация)
        float styleScore = generatedText.Contains(expectedStyle) ? 1.0f : 0.4f;

        // Итоговая награда (можно настраивать веса)
        return (syntaxScore * 0.4f + contextScore * 0.3f + styleScore * 0.3f);
    }
}
```

---
#### TextGenerator.Infrastructure/Reward/RewardCollector.cs @ 2026-04-07 17:27:37
```
﻿using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Models.Feedback;

namespace TextGenerator.Infrastructure.Reward;

public class RewardCollector : IRewardCollector
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

---
#### TextGenerator.Infrastructure/Services/NarrativeEnvironmentService.cs @ 2026-04-07 17:27:37
```
﻿using Microsoft.Extensions.Caching.Memory;
using Neo4j.Driver;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactors;


namespace TextGenerator.Infrastructure.Services;

public class NarrativeEnvironmentService : INarrativeEnvironment
{
    private readonly IDriver _neo4jDriver;
    private readonly IMemoryCache _cache;

    public async Task<WorldContext> GetRelevantContext(SmartNPC npc, Player player, string currentInput)
    {
        // 1. Получить местоположение, время суток
        // 2. Получить последние 5 событий из истории
        // 3. Получить связи NPC с другими персонажами
        // 4. Вернуть структурированный объект
        var context = new WorldContext();
        // ... реализация через Cypher-запросы
        return new WorldContext
        {
            LocationDescription = "Unknown location",
            RecentEvents = new List<string>(),
            EntityStates = new Dictionary<string, string>(),
            TimeOfDay = 12.0f
        };
    }

    public Task UpdateState(string entityId, string property, object value)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SocialConnection>> GetRelationships(int npcId)
    {
        throw new NotImplementedException();
    }

    public Task LogInteraction(string description, DateTime timestamp)
    {
        throw new NotImplementedException();
    }
}
```

---
#### TextGenerator.Infrastructure/Services/Processors/PostprocessorService.cs @ 2026-04-07 17:27:37
```
﻿using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;
using TextGenerator.Infrastructure.Extensions;

namespace TextGenerator.Infrastructure.Services.Processors
{
    public class PostprocessorService : IPostprocessor
    {
        private static string npcName = "";
        private static string playerName = "";

        public List<DialogueNode> DecodeAPISteppedDialogueResponse(SmartNPC npc, string prevNodeKey, string response)
        { 
            List<DialogueNode> dialogueNodes = new List<DialogueNode>();

            var result = ParseTextToDict(response);

            foreach (var line in result)
            {
                var node = new DialogueNode();
                node.Name = prevNodeKey == "" ? line.Key : prevNodeKey + line.Key;
                node.Childs = new List<DialogueNode>();
                node.InterlocutorNPC = npcName;
                node.NPCText = line.Value[npcName]["NPC"];
                node.InterlocutorPlayer = playerName;
                node.PlayerText = line.Value[playerName]["Player"];
                var level = line.Key.Split('.', (char)StringSplitOptions.RemoveEmptyEntries).Length;
                //Console.WriteLine(level);

                dialogueNodes.Add(node);
            }

            return dialogueNodes;
        }

        public DialogueEntry DecodeAPIBranchedDialogueResponse(SmartNPC npc, string response)
        {
            DialogueEntry dialogueEntry = new DialogueEntry();
            dialogueEntry.Childs = new List<DialogueNode>();

            string pattern = @"(?<variant>[0]{1})\s+(?<npcName>\w+)\s*:\s*""(?<npcPhrase>[^""]+)""";

            MatchCollection matches = Regex.Matches(response, pattern, RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                dialogueEntry.Text = match.Groups["npcPhrase"].Value;
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
                    dialogueEntry.AddChildToEntry(node);
                }
                else
                {
                    var parent = dialogueEntry.GetDialogueNodeByName(line.Key.Remove(line.Key.Length - 2));
                    parent.AddChildToNode(node);
                }
            }

            return dialogueEntry;
        }

        public Quest ParseQuest(string response)
        {
            // Извлечь JSON из ответа (модель может добавить пояснения)
            var jsonMatch = Regex.Match(response, @"\{[\s\S]*\}");
            if (!jsonMatch.Success) throw new ArgumentException("No JSON found");
            var quest = JsonConvert.DeserializeObject<Quest>(jsonMatch.Value);
            // Валидация полей
            if (quest.Difficulty < 1 || quest.Difficulty > 5) quest.Difficulty = 3;
            return quest;
        }

        private DialogueNode ParseBranch(string separator)
        {
            DialogueNode branch = new DialogueNode();
            return branch;
        }
        
        public DialogueNode DecodeSingleStepDialogueResponse(SmartNPC npc, string response)
        {
            // Парсим строку вида: "Игрок: \"...\" NPC: \"...\""
            var pattern = @"Игрок:\s*""(?<player>[^""]+)""\s+NPC:\s*""(?<npc>[^""]+)""";
            var match = Regex.Match(response, pattern);
            if (!match.Success) throw new FormatException("Invalid stepped response");
    
            return new DialogueNode
            {
                InterlocutorPlayer = "Игрок",
                PlayerText = match.Groups["player"].Value,
                InterlocutorNPC = npc.Name,
                NPCText = match.Groups["npc"].Value,
                Childs = new List<DialogueNode>()
            };
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
}
```

---
#### TextGenerator.Infrastructure/Services/Processors/PreprocessorService.cs @ 2026-04-07 17:27:37
```
﻿using Newtonsoft.Json;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Infrastructure.Services.Processors
{
    public class PreprocessorService : IPreprocessor
    {
        private readonly INarrativeEnvironment _narrativeEnv;

        public PreprocessorService(INarrativeEnvironment narrativeEnv)
        {
            _narrativeEnv = narrativeEnv;
        }
        
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

        public string GenerateQuestPrompt(SmartNPC npc, Player player, string goalDescription)
        {
            var context = _narrativeEnv.GetRelevantContext(npc, player, goalDescription).Result;
            return $@"
Ты – генератор квестов для RPG. Сгенерируй задание в формате JSON.
NPC: {npc.Name} (профессия: {npc.Profession})
Игрок: {player.Name}, уровень {player.Level}
Цель: {goalDescription}
Контекст мира: {JsonConvert.SerializeObject(context)}
Сложность должна быть между 1 и 5, награда – предметы или опыт.
Вывод ТОЛЬКО JSON:
{{
  ""name"": ""Название квеста"",
  ""description"": ""Описание"",
  ""difficulty"": 3,
  ""requirements"": [{{""type"": ""kill"", ""target"": ""goblin"", ""count"": 5}}],
  ""rewards"": [{{""type"": ""exp"", ""amount"": 100}}]
}}";
        }

        public string GenerateBasicSteppedDialogueRequest(SmartNPC npc, DialogueNode prevNode, int variety, WorldContext context)
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
                list.Add($"\n {i + 1}. Игрок: \"[Вариант {i + 1}]\" \n {npc.Name}: \"[Ответ на Вариант {i + 1}]\"");
            }

            string variantJoin = string.Join(" ", list);
            string formatter = $"Ответ должен быть в формате: {variantJoin}";
            string prompt = 
                $"{entry} (тип - {npc.Type}, возраст - {npc.Age} лет, внешность - {npc.Appearance}, профессия - {npc.Profession}). {characteristics}. {society}. {behavior}. {prevDialogueStep}. {formatter}. Длина фраз не более 2 предложений.";

            return prompt;
        }

        public string GenerateIntroductoryPhraseRequest(SmartNPC npc)
        {

            string entry = $"Сгенерируй вступительную фразу диалога для NPC {npc.Name}";
            string characteristics = $"Личностные качества: {string.Join(", ", npc.PersonalCharacteristics)}";
            string society = "Социальные связи: " + string.Join(", ",
                npc.SocialConnections.Select(con => $"{con.RelatedNPC.Name} (тип связи - {con.Type})"));
            string behavior = $"Поведение: {string.Join(", ", npc.Behaviors)}";
            string prompt = $"{entry} (тип - {npc.Type}, возраст - {npc.Age} лет, внешность - {npc.Appearance}, профессия - {npc.Profession}). {characteristics}. {society}. {behavior}. Напиши только фразу. Не более 2 предложений.";

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
```

---
#### TextGenerator.Infrastructure/Services/RAG/RAGService.cs @ 2026-04-07 17:27:37
```
﻿using System.Text;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.RAG;
using TextGenerator.Infrastructure.Memory;

namespace TextGenerator.Infrastructure.Services.RAG;

public class RAGService : IRAGService
{
    private readonly IMemory _memory;
    private readonly IVectorMemory _vectorizer;
    private readonly ISummarizer _summarizer;

    public RAGService(IMemory memory, IVectorMemory vectorizer, ISummarizer summarizer)
    {
        _memory = memory;
        _vectorizer = vectorizer;
        _summarizer = summarizer;
    }

    public async Task<string> AugmentPrompt(string userQuery, string basePrompt)
    {
        var embedding = _vectorizer.GetEmbedding(userQuery);
        // Получаем воспоминания с временными метками
        var memories = await _memory.RetrieveRelevantWithTimestamp(userQuery, embedding, topK: 3);
        
        if (memories.Count == 0) return basePrompt;
        
        // Сортируем по убыванию свежести (score уже учитывает косинусное сходство, но добавим временной коэффициент)
        var sorted = memories.OrderByDescending(m => m.Timestamp).Take(3);

        var context = new StringBuilder();
        context.AppendLine("Вот что NPC помнит о прошлых взаимодействиях (свежие воспоминания важнее):");
        foreach (var mem in memories)
            context.AppendLine($"- {mem.Text} (было {DateTime.Now.Subtract(mem.Timestamp).TotalHours:F1} ч. назад)");

        // Если общая длина промпта превышает лимит (например, 1800 токенов), вызываем суммаризатор
        var fullPrompt = $"{basePrompt}\n\n{context}";
        
        if (EstimateTokenCount(fullPrompt) > 1800)
        {
            var summary = await _summarizer.Summarize(context.ToString());
            fullPrompt = $"{basePrompt}\n\nКраткая памятка: {summary}";
        }
        return fullPrompt;
    }

    public async Task StoreInteraction(string text, string metadata)
    {
        var embedding = _vectorizer.GetEmbedding(text);
        await _memory.AddMemory(text, embedding, metadata);
    }
    
    private int EstimateTokenCount(string text)
    {
        // Простая эвристика: 1 токен ≈ 4 символов для английского, 2 символа для кириллицы.
        // В реальном проекте используйте настоящий токенизатор (например, LLamaSharp's Tokenizer).
        return (int)(text.Length * 0.75);
    }
}
```

---
#### TextGenerator.Infrastructure/TextGenerator.Infrastructure.csproj @ 2026-04-07 17:27:37
```
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <ImplicitUsings>enable</ImplicitUsings>
<LangVersion>10.0</LangVersion>
<GeneratePackageOnBuild>true</GeneratePackageOnBuild>
<PackageId>gpt-text-generator-infrastructure</PackageId>
<Title>GPTTextGenerator.Infrastructure</Title>
<Authors>InanisPluvia</Authors>
<PackageOutputPath>C:\Users\LordVT\Desktop\FinalQualifyingWork\src\csharp\NugetRepo</PackageOutputPath>
<Version>1.1.18</Version>
<Nullable>enable</Nullable>
<TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="FastBertTokenizer" Version="1.0.28" />
    <PackageReference Include="LLamaSharp" Version="0.26.0" />
    <PackageReference Include="LLamaSharp.semantic-kernel" Version="0.26.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.17" />
    <PackageReference Include="Microsoft.ML" Version="3.0.1" />
    <PackageReference Include="Microsoft.ML.OnnxRuntime" Version="1.18.0" />
    <PackageReference Include="Microsoft.ML.OnnxRuntime.Managed" Version="1.18.0" />
    <PackageReference Include="Microsoft.ML.OnnxTransformer" Version="3.0.1" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
    <PackageReference Include="Qdrant.Client" Version="1.17.0" />
    <PackageReference Include="RestSharp" Version="111.2.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\TextGenerator.Core\TextGenerator.Core.csproj" />
  </ItemGroup>

  <ItemGroup Condition="'$(TargetFramework)' == 'net8.0'">
    <PackageReference Include="LLamaSharp.Jinja.Executors" Version="1.0.0" />
    <PackageReference Include="Neo4j.Driver" Version="6.0.0" />
  </ItemGroup>

</Project>

```

---
#### TextGenerator.Service/Controllers/DialogueController.cs @ 2026-04-07 17:27:37
```
﻿using Microsoft.AspNetCore.Mvc;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DialogueController : ControllerBase
{
    private readonly INarrativeAgent _agent;

    public DialogueController(INarrativeAgent agent) => _agent = agent;

    [HttpPost("generate")]
    public async Task<ActionResult<DialogueEntry>> GenerateDialogue(
        [FromBody] DialogueRequest request)
    {
        var dialogue = await _agent.GenerateDialogue(
            request.Npc, request.Player, request.PlayerInput,
            request.Depth, request.Variety);
        return Ok(dialogue);
    }

    public class DialogueRequest
    {
        public SmartNPC Npc { get; set; }
        public Player Player { get; set; }
        public string PlayerInput { get; set; }
        public int Depth { get; set; } = 2;
        public int Variety { get; set; } = 3;
    }
}
```

---
#### TextGenerator.Service/Controllers/QuestController.cs @ 2026-04-07 17:27:37
```
﻿using Microsoft.AspNetCore.Mvc;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

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

---
#### TextGenerator.Service/GPTTextGenerator.Service.http @ 2026-04-07 17:27:37
```
@GPTTextGenerator.Service_HostAddress = http://localhost:5208

GET {{GPTTextGenerator.Service_HostAddress}}/weatherforecast/
Accept: application/json

###

```

---
#### TextGenerator.Service/Program.cs @ 2026-04-07 17:27:37
```
using TextGenerator.Core.Interfaces.Cache;
using TextGenerator.Core.Interfaces.EdgeAI;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Interfaces.RAG;
using TextGenerator.Infrastructure.Agents;
using TextGenerator.Infrastructure.Analyzer;
using TextGenerator.Infrastructure.Caching;
using TextGenerator.Infrastructure.EdgeAI;
using TextGenerator.Infrastructure.Memory;
using TextGenerator.Infrastructure.Reward;
using TextGenerator.Infrastructure.Services;
using TextGenerator.Infrastructure.Services.Processors;
using TextGenerator.Infrastructure.Services.RAG;

var builder = WebApplication.CreateBuilder(args);


// 1. Конфигурация локальной LLM
builder.Services.Configure<LLamaSharpOptions>(builder.Configuration.GetSection("LocalLLM"));
builder.Services.AddSingleton<ILLMClient, LocalLLMClient>();

// 2. Компоненты памяти и RAG
builder.Services.AddSingleton<IVectorMemory, VectorMemoryService>();
builder.Services.AddSingleton<IMemory, QdrantMemory>(); // требуется Qdrant.Client
builder.Services.AddScoped<IRAGService, RAGService>();
builder.Services.AddScoped<ISummarizer, Summarizer>();
builder.Services.AddScoped<IDialogueCache, DialogueCache>();
builder.Services.AddMemoryCache(); // IMemoryCache

// 3. Narrative Environment
builder.Services.AddSingleton<INarrativeEnvironment, NarrativeEnvironmentService>();

// 4. Пре/постпроцессоры
builder.Services.AddScoped<IPreprocessor, PreprocessorService>();
builder.Services.AddScoped<IPostprocessor, PostprocessorService>();

// 5. Система наград и метрик
builder.Services.AddSingleton<IAnalyzer, DialogueAnalyzer>(); // если модель ONNX доступна
builder.Services.AddSingleton<IRewardCalculator, RewardCalculator>();
builder.Services.AddSingleton<IRewardCollector, RewardCollector>();

// 6. Нарративный агент
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

---
#### TextGenerator.Service/Properties/launchSettings.json @ 2026-04-07 17:27:37
```json
﻿{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:52562",
      "sslPort": 44354
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5208",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7250;http://localhost:5208",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}

```

---
#### TextGenerator.Service/TextGenerator.Service.csproj @ 2026-04-07 17:27:37
```
<Project Sdk="Microsoft.NET.Sdk.Web">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <Nullable>enable</Nullable>
        <ImplicitUsings>enable</ImplicitUsings>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.25"/>
        <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2"/>
    </ItemGroup>

    <ItemGroup>
      <ProjectReference Include="..\TextGenerator.Infrastructure\TextGenerator.Infrastructure.csproj" />
    </ItemGroup>

</Project>

```

---
#### TextGenerator.Service/appsettings.Development.json @ 2026-04-07 17:27:37
```json
{
  "LocalLLM": {
    "ModelPath": "models/llama-3-8b-q4.gguf"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}

```

---
#### TextGenerator.Service/appsettings.json @ 2026-04-07 17:27:37
```json
{
  "LocalLLM": {
    "ModelPath": "models/llama-3-8b-q4.gguf"
  }
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

---
