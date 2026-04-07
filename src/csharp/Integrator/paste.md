## File Tree @ 2026-04-07 15:37:13
```
├── Integrator.sln
├── TextGenerator.Core/
│   ├── Enums/
│   │   ├── ItemType.cs
│   │   ├── StatType.cs
│   │   └── Status.cs
│   ├── Interfaces/
│   │   ├── IBase.cs
│   │   ├── IPlugin.cs
│   │   ├── IRepository.cs
│   │   ├── Memorize/
│   │   │   ├── IMemory.cs
│   │   │   ├── INarrativeAgent.cs
│   │   │   └── IRewardSystem.cs
│   │   └── Processors/
│   │       ├── IAnalyzer.cs
│   │       ├── IPostprocessor.cs
│   │       └── IPreprocessor.cs
│   ├── Models/
│   │   ├── Actions/
│   │   │   ├── Action.cs
│   │   │   ├── Reaction.cs
│   │   │   ├── Requirement.cs
│   │   │   └── SocialConnection.cs
│   │   ├── Interactions/
│   │   │   ├── ChainQuest.cs
│   │   │   ├── DialogueEntry.cs
│   │   │   ├── DialogueNode.cs
│   │   │   └── Quest.cs
│   │   ├── Interactors/
│   │   │   ├── Environment.cs
│   │   │   ├── Player.cs
│   │   │   └── SmartNPC.cs
│   │   ├── Misc/
│   │   │   ├── PObject.cs
│   │   │   └── Stat.cs
│   │   └── Objects/
│   │       ├── Inventory.cs
│   │       ├── Item.cs
│   │       └── Reward.cs
│   └── TextGenerator.Core.csproj
├── TextGenerator.Infrastructure/
│   ├── API/
│   │   └── GptApiClient.cs
│   ├── Agents/
│   │   └── NarrativeAgent.cs
│   ├── Analyzer/
│   │   └── Analyzer.cs
│   ├── Contexts/
│   │   └── BasicDbContext.cs
│   ├── EdgeAI/
│   │   ├── LocalLLMClient.cs
│   │   └── ModelDownloader.cs
│   ├── Extensions/
│   │   ├── ClientExtension.cs
│   │   └── DialogueExtension.cs
│   ├── Helpers/
│   │   └── DialogueHelper.cs
│   ├── Memory/
│   │   ├── QdrantMemory.cs
│   │   ├── Summarizer.cs
│   │   └── VectorMemoryService.cs
│   ├── Processors/
│   │   ├── Postprocessor.cs
│   │   └── Preprocessor.cs
│   ├── RAG/
│   │   └── RAGService.cs
│   ├── Repositories/
│   │   ├── ChainQuestRepository.cs
│   │   ├── DialogueEntryRepository.cs
│   │   ├── DialogueNodeRepository.cs
│   │   ├── EnvironmentRepository.cs
│   │   ├── NPCRepository.cs
│   │   ├── PlayerRepository.cs
│   │   └── QuestRepository.cs
│   ├── Reward/
│   │   └── RewardCalculator.cs
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

## File Analysis @ 2026-04-07 15:37:13
- Total files: 62
- .cs: 54
- .csproj: 3
- .http: 1
- .json: 3
- .sln: 1


---
#### Integrator.sln @ 2026-04-07 15:37:13
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
#### TextGenerator.Core/Enums/ItemType.cs @ 2026-04-07 15:37:13
```
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator.Core.Enums
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
#### TextGenerator.Core/Enums/StatType.cs @ 2026-04-07 15:37:13
```
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator.Core.Enums
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
#### TextGenerator.Core/Enums/Status.cs @ 2026-04-07 15:37:13
```
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator.Core.Enums
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
#### TextGenerator.Core/Interfaces/IBase.cs @ 2026-04-07 15:37:13
```
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator.Core.Interfaces
{
    public interface IBase
    {
        public int Id { get; }
    }
}

```

---
#### TextGenerator.Core/Interfaces/IPlugin.cs @ 2026-04-07 15:37:13
```
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator.Core.Interfaces
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        void GenerateQuest();
    }
}
```

---
#### TextGenerator.Core/Interfaces/IRepository.cs @ 2026-04-07 15:37:13
```
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<List<T>> GetAllAsync();
        T GetById(int id);
        T GetByIdWithIncludes(int id);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdWithIncludesAsync(int id);
        bool Remove(int id);
        void Add(in T sender);
        void Update(in T sender);
        int Save();
        Task<int> SaveAsync();
        public T Select(Expression<Func<T, bool>> predicate);
        public Task<T> SelectAsync(Expression<Func<T, bool>> predicate);
    }
}

```

---
#### TextGenerator.Core/Interfaces/Memorize/IMemory.cs @ 2026-04-07 15:37:13
```
﻿namespace TextGenerator.Core.Interfaces.Memorize;

public interface IMemory
{
    Task AddMemory(string text, float[] embedding, string metadata);
    Task<List<(string Text, float Score)>> RetrieveRelevant(string query, float[] queryEmbedding, int topK = 5);
}
```

---
#### TextGenerator.Core/Interfaces/Memorize/INarrativeAgent.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Memorize;

public interface INarrativeAgent
{
    Task<DialogueEntry> GenerateDialogue(SmartNPC npc, Player player, string playerInput, int depth, int variety);
    Task<Quest> GenerateQuest(SmartNPC npc, Player player, string goalDescription);
}
```

---
#### TextGenerator.Core/Interfaces/Memorize/IRewardSystem.cs @ 2026-04-07 15:37:13
```
﻿namespace TextGenerator.Core.Interfaces.Memorize;

public interface IRewardSystem
{
    float CalculateReward(string generatedText, string context, string expectedStyle);
}
```

---
#### TextGenerator.Core/Interfaces/Processors/IAnalyzer.cs @ 2026-04-07 15:37:13
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
#### TextGenerator.Core/Interfaces/Processors/IPostprocessor.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Processors
{
    public interface IPostprocessor
    {
        DialogueEntry DecodeAPIBranchedDialogueResponse(SmartNPC npc, string response);

        Quest ParseQuest(string response);
        //Quest ParseQuest();
        //bool CheckСorrectness(); // планирую написать нейронку с подкреплением на python подключу с IronPython
    }
}

```

---
#### TextGenerator.Core/Interfaces/Processors/IPreprocessor.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Interfaces.Processors
{
    public interface IPreprocessor
    {
        string GenerateBasicBranchedDialogueRequest(SmartNPC npc, int depth, int variety);
        string GenerateQuestPrompt(SmartNPC npc, Player player, string goalDescription);
    }
}

```

---
#### TextGenerator.Core/Models/Actions/Action.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Actions
{
    public class Action : IBase
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
#### TextGenerator.Core/Models/Actions/Reaction.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Actions
{
    public class Reaction : IBase
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
#### TextGenerator.Core/Models/Actions/Requirement.cs @ 2026-04-07 15:37:13
```
﻿using System;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Actions
{
    public class Requirement : IBase
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
#### TextGenerator.Core/Models/Actions/SocialConnection.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Core.Models.Actions
{
    public class SocialConnection : IBase
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
#### TextGenerator.Core/Models/Interactions/ChainQuest.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Interactions
{
    public class ChainQuest : IBase
    {
        public int Id => ChainQuestId;
        public int ChainQuestId { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Interactions/DialogueEntry.cs @ 2026-04-07 15:37:13
```
﻿using System.Collections.Generic;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Interactions
{
    public class DialogueEntry : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Text { get; set; }

        public List<DialogueNode> Childs { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Interactions/DialogueNode.cs @ 2026-04-07 15:37:13
```
﻿using System.Collections.Generic;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Interactions
{
    public class DialogueNode : IBase
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
#### TextGenerator.Core/Models/Interactions/Quest.cs @ 2026-04-07 15:37:13
```
﻿using System.Collections.Generic;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Objects;

namespace TextGenerator.Core.Models.Interactions
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

```

---
#### TextGenerator.Core/Models/Interactors/Environment.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Models.Interactors;
using System.Collections.Generic;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Misc;

namespace TextGenerator.Core.Models.Interactors
{
    public class Environment : IBase
    {
        public int Id => EnvironmentId;
        public int EnvironmentId { get; set; }
        public IEnumerable<SmartNPC> SmartNPCs { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<PObject> Objects { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Interactors/Player.cs @ 2026-04-07 15:37:13
```
﻿using System.Numerics;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Objects;
using Action = TextGenerator.Core.Models.Actions.Action;

namespace TextGenerator.Core.Models.Interactors
{
    public class Player : IBase
    {
        public int Id => ID;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Vector3 Position { get; set; }
        public int Health { get; set; }
        public Inventory Inventory { get; set; }
        public List<DialogueEntry> Dialogues { get; set; }
        public List<Reaction> Reactions { get; set; }
        public List<Action> Actions { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Interactors/SmartNPC.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Actions;
using TextGenerator.Core.Models.Interactions;
using Action = TextGenerator.Core.Models.Actions.Action;

namespace TextGenerator.Core.Models.Interactors
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

```

---
#### TextGenerator.Core/Models/Misc/PObject.cs @ 2026-04-07 15:37:13
```
﻿using System.Collections.Generic;
using TextGenerator.Core.Enums;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Misc
{
    public class PObject : IBase
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
#### TextGenerator.Core/Models/Misc/Stat.cs @ 2026-04-07 15:37:13
```
﻿using System;
using TextGenerator.Core.Enums;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Misc
{
    public class Stat : IBase
    {
        public int Id => StatId;
        public int StatId { get; set; }
        public StatType StatType { get; set; }
        public float Value { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Objects/Inventory.cs @ 2026-04-07 15:37:13
```
﻿using System.Collections.Generic;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Objects
{
    public class Inventory : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public int OwnerID { get; set; } // Ссылка на владельца инвентаря
        public List<Item> Items { get; set; }
    }
}

```

---
#### TextGenerator.Core/Models/Objects/Item.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Enums;
using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Objects
{
    public class Item : IBase
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
#### TextGenerator.Core/Models/Objects/Reward.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;

namespace TextGenerator.Core.Models.Objects
{
    public class Reward : IBase
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
#### TextGenerator.Core/TextGenerator.Core.csproj @ 2026-04-07 15:37:13
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
#### TextGenerator.Infrastructure/API/GptApiClient.cs @ 2026-04-07 15:37:13
```
﻿using System.Text;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;
using RestSharp;
using Newtonsoft.Json;
using System.Net;

namespace TextGenerator.Infrastructure.API
{
    public class RootResponse
    {
        public List<Choice> choices { get; set; }
    }

    public class Choice
    {
        public Message message { get; set; }
    }

    public class Message
    {
        public string content { get; set; }
    }

    public class GptApiClient
    {
        private readonly RestClient _restClient;
        private readonly string _baseApiUrl;
        private readonly string _apiKey;
        private readonly string _model;

        public GptApiClient(string apiKey, string baseApiUrl, string model)
        {
            _apiKey = apiKey;
            _baseApiUrl = baseApiUrl;
            _model = model;
            _restClient = new RestClient(_baseApiUrl);
        }

        public async Task<string> SendRequest(string prompt)
        {
            try
            {
                var request = new RestRequest("chat/completions", Method.Post);
                request.AddHeader("Authorization", $"Bearer {_apiKey}");
                request.AddJsonBody(new
                {
                    model = _model,
                    messages = new List<dynamic> { new { role = "user", content = prompt } },
                    temperature = 0.7,
                    n = 1,
                    max_tokens = Convert.ToInt32(prompt.Length * 1.5),
                    extra_headers = new { X_Title = "My App" } // опционально - передача информации об источнике API-вызова
                });

                var response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseData = JsonConvert.DeserializeObject<RootResponse>(response.Content);
                    return responseData.choices[0].message.content;
                }
                else
                {
                    return "Error: " + response.StatusCode;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}

```

---
#### TextGenerator.Infrastructure/Agents/NarrativeAgent.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces.Memorize;
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
```

---
#### TextGenerator.Infrastructure/Analyzer/Analyzer.cs @ 2026-04-07 15:37:13
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

    public class Analyzer : IAnalyzer
    {
        private static BertTokenizer tokenizer;
        private InferenceSession _onnxSession;

        public Analyzer()
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
#### TextGenerator.Infrastructure/Contexts/BasicDbContext.cs @ 2026-04-07 15:37:13
```
﻿using Microsoft.EntityFrameworkCore;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Interactions;
using System.Linq.Expressions;

namespace TextGenerator.Infrastructure.Contexts
{
    public class BasicDbContext : DbContext
    {
        public DbSet<DialogueEntry> DialogueEntries { get; set; }
        public DbSet<DialogueNode> DialogueNodes { get; set; }

        public BasicDbContext(DbContextOptions<BasicDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DialogueEntry>(entity =>
            {
                entity.HasKey(x => x.ID);
                entity.HasMany(x => x.Childs)
                      .WithOne()
                      .HasForeignKey(x => x.ID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DialogueNode>(entity =>
            {
                entity.HasKey(x => x.ID);
                entity.HasMany(x => x.Childs)
                      .WithOne()
                      .HasForeignKey(x => x.ID)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

```

---
#### TextGenerator.Infrastructure/EdgeAI/LocalLLMClient.cs @ 2026-04-07 15:37:13
```
﻿using LLama;
using LLama.Common;
using Microsoft.Extensions.Options;
using System.Text;
using LLama.Sampling;

namespace TextGenerator.Infrastructure.EdgeAI;

public class LocalLLMClient
{
    private readonly InteractiveExecutor _executor;
    private readonly LLamaContext _context;

    public LocalLLMClient(IOptions<LLamaSharpOptions> options)
    {
        var modelPath = options.Value.ModelPath;
        var parameters = new ModelParams(modelPath)
        {
            ContextSize = 2048,
            GpuLayerCount = 20,   // использовать GPU
            BatchSize = 512
        };
        var model = LLamaWeights.LoadFromFile(parameters);
        _context = model.CreateContext(parameters);
        _executor = new InteractiveExecutor(_context);
    }

    public async Task<string> GenerateAsync(string prompt, int maxTokens = 256)
    {
        var inferenceParams = new InferenceParams
        {
            MaxTokens = maxTokens,
            AntiPrompts = new[] { "\nИгрок:", "\nNPC:" },
            SamplingPipeline = new DefaultSamplingPipeline
            {
                Temperature = 0.7f
            }
        };

        var result = new StringBuilder();

        await foreach (var token in _executor.InferAsync(prompt, inferenceParams))
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
#### TextGenerator.Infrastructure/EdgeAI/ModelDownloader.cs @ 2026-04-07 15:37:13
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
#### TextGenerator.Infrastructure/Extensions/ClientExtension.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;
using TextGenerator.Infrastructure.Helpers;
using TextGenerator.Infrastructure.API;

namespace TextGenerator.Infrastructure.Extensions
{
    public static class ClientExtension
    {
        private static async Task<string> GenerateIntroductoryPhrase(this GptApiClient client, SmartNPC npc)
        {
            string prompt = npc.GenerateIntroductoryPhraseRequest();
            string response = await client.SendRequest(prompt);

            return response;
        }

        public static async Task<DialogueEntry> GenerateDialogueTree(this GptApiClient client, SmartNPC npc, int depth, int variety)
        {
            DialogueEntry root = new();
            root.Text = await client.GenerateIntroductoryPhrase(npc);
            root.Childs = new List<DialogueNode>();

            List<DialogueNode> currentNodes = new List<DialogueNode>();
            currentNodes.Add(new DialogueNode { Name = "", NPCText = root.Text, InterlocutorNPC = npc.Name, PlayerText = "", InterlocutorPlayer = "Игрок" });

            for (int i = 0; i < depth; i++)
            {
                List<DialogueNode> newNodes = new List<DialogueNode>();

                foreach (DialogueNode parentNode in currentNodes)
                {
                    parentNode.Childs = new List<DialogueNode>();
                    string stepPrompt = npc.GenerateBasicSteppedDialogueRequest(parentNode, variety);
                    string response = await client.SendRequest(stepPrompt);

                    List<DialogueNode> childNodes = npc.DecodeAPISteppedDialogueResponse(parentNode.Name, response);

                    foreach (DialogueNode childNode in childNodes)
                    {
                        if (i == 0)
                        {
                            root.Childs.Add(childNode); // Add child node to the root node at the initial step
                        }
                        else
                        {
                            parentNode.Childs.Add(childNode); // Add child node to the parent node for subsequent steps
                        }

                        newNodes.Add(childNode); // Add child node to the list of current nodes
                    }
                }

                currentNodes = newNodes;
            }

            return root;
        }
    }
}

```

---
#### TextGenerator.Infrastructure/Extensions/DialogueExtension.cs @ 2026-04-07 15:37:13
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
    public static class DialogueExtension
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
#### TextGenerator.Infrastructure/Helpers/DialogueHelper.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;
using Analyzer = TextGenerator.Infrastructure.Analyzer.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGenerator.Infrastructure.Processors;

namespace TextGenerator.Infrastructure.Helpers
{
    public static class DialogueHelper
    {
        public static string GenerateBasicSteppedDialogueRequest(this SmartNPC npc, DialogueNode prevNode, int variety)
            => new Preprocessor().GenerateBasicSteppedDialogueRequest(npc, prevNode, variety);

        public static string GenerateBasicBranchedDialogueRequest(this SmartNPC npc, int depth, int variety)
            => new Preprocessor().GenerateBasicBranchedDialogueRequest(npc, depth, variety);

        public static string GenerateIntroductoryPhraseRequest(this SmartNPC npc)
            => new Preprocessor().GenerateIntroductoryPhraseRequest(npc);

        public static List<DialogueNode> DecodeAPISteppedDialogueResponse(this SmartNPC npc, string prevNodeKey, string response)
            => new Postprocessor().DecodeAPISteppedDialogueResponse(npc, prevNodeKey, response);

        public static DialogueEntry DecodeAPIBranchedDialogueResponse(this SmartNPC npc, string response)
            => new Postprocessor().DecodeAPIBranchedDialogueResponse(npc, response);

        public static List<string> GetAllDialogueBranches(this DialogueEntry entry)
            => new List<string>();

        public static bool CheckDialogueCorrection(this List<string> dialogueBranches)
            => true;
    }
}

```

---
#### TextGenerator.Infrastructure/Memory/QdrantMemory.cs @ 2026-04-07 15:37:13
```
﻿using Google.Protobuf.Collections;
using Qdrant.Client;
using Qdrant.Client.Grpc;
using TextGenerator.Core.Interfaces.Memorize;

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
            // Convert float[] to ReadOnlyMemory<float>
            var vectorMemory = new ReadOnlyMemory<float>(embedding);

            // Build payload as MapField<string, Value>
            var payload = new MapField<string, Value>
            {
                { "text", new Value { StringValue = text } },
                { "metadata", new Value { StringValue = metadata } }
            };

            var point = new PointStruct
            {
                Id = Guid.NewGuid(),
                Vectors = new Vectors
                {
                    Vector = embedding
                }
            };
            
            point.Payload.Add("text", new Value { StringValue = text });
            point.Payload.Add("metadata", new Value { StringValue = metadata });

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
    }
```

---
#### TextGenerator.Infrastructure/Memory/Summarizer.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Infrastructure.EdgeAI;

namespace TextGenerator.Infrastructure.Memory;

public class Summarizer
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
#### TextGenerator.Infrastructure/Memory/VectorMemoryService.cs @ 2026-04-07 15:37:13
```
﻿using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace TextGenerator.Infrastructure.Memory;

public class VectorMemoryService
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
#### TextGenerator.Infrastructure/Processors/Postprocessor.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;
using TextGenerator.Infrastructure.Extensions;
using System.Text.RegularExpressions;

namespace TextGenerator.Infrastructure.Processors
{
    public class Postprocessor : IPostprocessor
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
            throw new NotImplementedException();
        }

        private DialogueNode ParseBranch(string separator)
        {
            DialogueNode branch = new DialogueNode();
            return branch;
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
#### TextGenerator.Infrastructure/Processors/Preprocessor.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;

namespace TextGenerator.Infrastructure.Processors
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

        public string GenerateQuestPrompt(SmartNPC npc, Player player, string goalDescription)
        {
            throw new NotImplementedException();
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
#### TextGenerator.Infrastructure/RAG/RAGService.cs @ 2026-04-07 15:37:13
```
﻿using System.Text;
using TextGenerator.Core.Interfaces.Memorize;
using TextGenerator.Infrastructure.Memory;

namespace TextGenerator.Infrastructure.RAG;

public class RAGService
{
    private readonly IMemory _memory;
    private readonly VectorMemoryService _vectorizer;

    public RAGService(IMemory memory, VectorMemoryService vectorizer)
    {
        _memory = memory;
        _vectorizer = vectorizer;
    }

    public async Task<string> AugmentPrompt(string userQuery, string basePrompt)
    {
        var embedding = _vectorizer.GetEmbedding(userQuery);
        var memories = await _memory.RetrieveRelevant(userQuery, embedding, topK: 3);
        if (memories.Count == 0) return basePrompt;

        var context = new StringBuilder();
        context.AppendLine("Вот что NPC помнит о прошлых взаимодействиях:");
        foreach (var mem in memories)
            context.AppendLine($"- {mem.Text}");

        return $"{basePrompt}\n\n{context}\nОтветь, учитывая эту память.";
    }

    public async Task StoreInteraction(string text, string metadata)
    {
        var embedding = _vectorizer.GetEmbedding(text);
        await _memory.AddMemory(text, embedding, metadata);
    }
}
```

---
#### TextGenerator.Infrastructure/Repositories/ChainQuestRepository.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Interactions;
using System.Linq.Expressions;

namespace TextGenerator.Infrastructure.Repositories
{
    public class ChainQuestRepository : IRepository<ChainQuest>
    {
        public void Add(in ChainQuest sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChainQuest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<ChainQuest>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ChainQuest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ChainQuest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ChainQuest GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ChainQuest> GetByIdWithIncludesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public ChainQuest Select(Expression<Func<ChainQuest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ChainQuest> SelectAsync(Expression<Func<ChainQuest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(in ChainQuest sender)
        {
            throw new NotImplementedException();
        }
    }
}

```

---
#### TextGenerator.Infrastructure/Repositories/DialogueEntryRepository.cs @ 2026-04-07 15:37:13
```
﻿using Microsoft.EntityFrameworkCore;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Interactions;
using System.Linq.Expressions;
using TextGenerator.Infrastructure.Contexts;

namespace TextGenerator.Infrastructure.Repositories
{
    public class DialogueEntryRepository : IRepository<DialogueEntry>
    {
        private readonly BasicDbContext _dbContext;

        public DialogueEntryRepository(BasicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(in DialogueEntry entry)
        {
            _dbContext.DialogueEntries.Add(entry);

            foreach (var node in entry.Childs)
            {
                AddDialogueNodeAndChildren(node);
            }

            _dbContext.SaveChanges();
        }

        private void AddDialogueNodeAndChildren(DialogueNode node)
        {
            _dbContext.DialogueNodes.Add(node);

            if (node.Childs != null && node.Childs.Any())
            {
                foreach (var childNode in node.Childs)
                {
                    AddDialogueNodeAndChildren(childNode);
                }
            }
        }

        public IEnumerable<DialogueEntry> GetAll()
            => _dbContext.DialogueEntries.Include(x => x.Childs).ToList();

        public Task<List<DialogueEntry>> GetAllAsync()
            => _dbContext.DialogueEntries.Include(x => x.Childs).ToListAsync();

        public DialogueEntry GetById(int id) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefault(x => x.ID == id);

        public Task<DialogueEntry> GetByIdAsync(int id) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefaultAsync(x => x.ID == id);

        public DialogueEntry GetByIdWithIncludes(int id) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefault(x => x.ID == id);

        public Task<DialogueEntry> GetByIdWithIncludesAsync(int id) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefaultAsync(x => x.ID == id);

        public bool Remove(int id)
        {
            var entry = _dbContext.DialogueEntries.FirstOrDefault(x => x.ID == id);
            if (entry != null)
            {
                _dbContext.DialogueEntries.Remove(entry);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public int Save()
            => _dbContext.SaveChanges();

        public Task<int> SaveAsync()
            => _dbContext.SaveChangesAsync();
        

        public DialogueEntry Select(Expression<Func<DialogueEntry, bool>> predicate) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefault(predicate);

        public Task<DialogueEntry> SelectAsync(Expression<Func<DialogueEntry, bool>> predicate) 
            => _dbContext.DialogueEntries.Include(x => x.Childs)
                                         .FirstOrDefaultAsync(predicate);

        public void Update(in DialogueEntry entry)
        {
            _dbContext.DialogueEntries.Update(entry);
            _dbContext.SaveChanges();
        }
    }
}

```

---
#### TextGenerator.Infrastructure/Repositories/DialogueNodeRepository.cs @ 2026-04-07 15:37:13
```
﻿using Microsoft.EntityFrameworkCore;
using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Interactions;
using System.Linq.Expressions;
using System.Linq;                    // LINQ
using TextGenerator.Infrastructure.Contexts;

namespace TextGenerator.Infrastructure.Repositories
{
    public class DialogueNodeRepository : IRepository<DialogueNode>
    {
        private readonly BasicDbContext _dbContext;

        public DialogueNodeRepository(BasicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(in DialogueNode sender)
        {
            _dbContext.DialogueNodes.Add(sender);
            _dbContext.SaveChanges();
        }

        public IEnumerable<DialogueNode> GetAll()
            => _dbContext.DialogueNodes.ToList();

        public async Task<List<DialogueNode>> GetAllAsync()
            => await _dbContext.DialogueNodes.AsQueryable().ToListAsync();

        public DialogueNode GetById(int id) 
            => _dbContext.DialogueNodes.FirstOrDefault(x => x.ID == id);

        public async Task<DialogueNode> GetByIdAsync(int id) 
            => await _dbContext.DialogueNodes.AsQueryable().FirstOrDefaultAsync(x => x.ID == id);

        // Add any necessary includes here
        public DialogueNode GetByIdWithIncludes(int id)
            => _dbContext.DialogueNodes.Include(x => x.Childs).FirstOrDefault(x => x.ID == id);

        // Add any necessary includes here
        public Task<DialogueNode> GetByIdWithIncludesAsync(int id)
            => _dbContext.DialogueNodes.Include(x => x.Childs).FirstOrDefaultAsync(x => x.ID == id);

        public bool Remove(int id)
        {
            var entity = _dbContext.DialogueNodes.FirstOrDefault(x => x.ID == id);
            if (entity != null)
            {
                _dbContext.DialogueNodes.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public int Save()
            => _dbContext.SaveChanges();
       
        public Task<int> SaveAsync()
            => _dbContext.SaveChangesAsync();

        public DialogueNode Select(Expression<Func<DialogueNode, bool>> predicate)
            => _dbContext.DialogueNodes.FirstOrDefault(predicate);

        public Task<DialogueNode> SelectAsync(Expression<Func<DialogueNode, bool>> predicate)
            => _dbContext.DialogueNodes.FirstOrDefaultAsync(predicate);

        public void Update(in DialogueNode sender)
        {
            _dbContext.Entry(sender).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

```

---
#### TextGenerator.Infrastructure/Repositories/EnvironmentRepository.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Interactors;
using System.Linq.Expressions;
using Environment = TextGenerator.Core.Models.Interactors.Environment;

namespace TextGenerator.Infrastructure.Repositories
{
    public class EnvironmentRepository : IRepository<Environment>
    {
        public void Add(in Environment sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Environment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Environment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Environment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Environment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Environment GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Environment> GetByIdWithIncludesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Environment Select(Expression<Func<Environment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Environment> SelectAsync(Expression<Func<Environment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(in Environment sender)
        {
            throw new NotImplementedException();
        }
    }
}

```

---
#### TextGenerator.Infrastructure/Repositories/NPCRepository.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Interactors;
using System.Linq.Expressions;

namespace TextGenerator.Infrastructure.Repositories
{
    public class NPCRepository : IRepository<SmartNPC>
    {
        public void Add(in SmartNPC sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SmartNPC> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<SmartNPC>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public SmartNPC GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SmartNPC> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public SmartNPC GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SmartNPC> GetByIdWithIncludesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public SmartNPC Select(Expression<Func<SmartNPC, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<SmartNPC> SelectAsync(Expression<Func<SmartNPC, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(in SmartNPC sender)
        {
            throw new NotImplementedException();
        }
    }
}

```

---
#### TextGenerator.Infrastructure/Repositories/PlayerRepository.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Interactors;
using System.Linq.Expressions;

namespace TextGenerator.Infrastructure.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        public void Add(in Player sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Player GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Player GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetByIdWithIncludesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Player Select(Expression<Func<Player, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Player> SelectAsync(Expression<Func<Player, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(in Player sender)
        {
            throw new NotImplementedException();
        }
    }
}

```

---
#### TextGenerator.Infrastructure/Repositories/QuestRepository.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces;
using TextGenerator.Core.Models.Interactions;
using System.Linq.Expressions;

namespace TextGenerator.Infrastructure.Repositories
{
    public class QuestRepository : IRepository<Quest>
    {
        public void Add(in Quest sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Quest>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Quest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Quest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Quest GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Quest> GetByIdWithIncludesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Quest Select(Expression<Func<Quest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Quest> SelectAsync(Expression<Func<Quest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(in Quest sender)
        {
            throw new NotImplementedException();
        }
    }
}

```

---
#### TextGenerator.Infrastructure/Reward/RewardCalculator.cs @ 2026-04-07 15:37:13
```
﻿using TextGenerator.Core.Interfaces.Memorize;

namespace TextGenerator.Infrastructure.Reward;

public class RewardCalculator : IRewardSystem
{
    private readonly Analyzer.Analyzer _analyzer;

    public RewardCalculator(Analyzer.Analyzer analyzer) => _analyzer = analyzer;

    public float CalculateReward(string generatedText, string context, string expectedStyle)
    {
        // 1. Синтаксическая корректность (0-1)
        float syntaxScore = _analyzer.CheckCorrections(new List<string> { generatedText }) ? 1.0f : 0.3f;

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
#### TextGenerator.Infrastructure/TextGenerator.Infrastructure.csproj @ 2026-04-07 15:37:13
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
<TargetFrameworks>netstandard2.1;net8.0</TargetFrameworks>
<Nullable>enable</Nullable>
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
  </ItemGroup>

</Project>

```

---
#### TextGenerator.Service/Controllers/DialogueController.cs @ 2026-04-07 15:37:13
```
﻿using Microsoft.AspNetCore.Mvc;
using TextGenerator.Core.Interfaces.Memorize;
using TextGenerator.Core.Models.Interactions;
using TextGenerator.Core.Models.Interactors;
using TextGenerator.Infrastructure.API;
using TextGenerator.Infrastructure.Extensions;
using TextGenerator.Infrastructure.Helpers;

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
#### TextGenerator.Service/Controllers/QuestController.cs @ 2026-04-07 15:37:13
```
﻿using Microsoft.AspNetCore.Mvc;
using TextGenerator.Core.Interfaces.Memorize;
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
#### TextGenerator.Service/GPTTextGenerator.Service.http @ 2026-04-07 15:37:13
```
@GPTTextGenerator.Service_HostAddress = http://localhost:5208

GET {{GPTTextGenerator.Service_HostAddress}}/weatherforecast/
Accept: application/json

###

```

---
#### TextGenerator.Service/Program.cs @ 2026-04-07 15:37:13
```
using TextGenerator.Core.Interfaces.Memorize;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Infrastructure.Agents;
using TextGenerator.Infrastructure.API;
using TextGenerator.Infrastructure.Processors;
using TextGenerator.Infrastructure.Analyzer;
using TextGenerator.Infrastructure.EdgeAI;
using TextGenerator.Infrastructure.Memory;
using TextGenerator.Infrastructure.RAG;
using TextGenerator.Infrastructure.Reward;

var builder = WebApplication.CreateBuilder(args);

// Настройка OpenAI
var openAIConfig = builder.Configuration.GetSection("OpenAI");
var apiKey = openAIConfig["ApiKey"] ?? throw new InvalidOperationException("OpenAI ApiKey missing");
var baseUrl = openAIConfig["BaseUrl"] ?? "https://api.openai.com/v1/";
var model = openAIConfig["Model"] ?? "gpt-3.5-turbo";

builder.Services.AddSingleton(new GptApiClient(apiKey, baseUrl, model));

// 1. Конфигурация локальной LLM
builder.Services.Configure<LLamaSharpOptions>(builder.Configuration.GetSection("LocalLLM"));
builder.Services.AddSingleton<LocalLLMClient>();

// 2. Компоненты памяти и RAG
builder.Services.AddSingleton<VectorMemoryService>();
builder.Services.AddSingleton<IMemory, QdrantMemory>(); // требуется Qdrant.Client
builder.Services.AddScoped<RAGService>();
builder.Services.AddScoped<Summarizer>();

// 3. Пре/постпроцессоры
builder.Services.AddScoped<IPreprocessor, Preprocessor>();
builder.Services.AddScoped<IPostprocessor, Postprocessor>();

// 4. Система наград
builder.Services.AddSingleton<IAnalyzer, Analyzer>(); // если модель ONNX доступна
builder.Services.AddSingleton<IRewardSystem, RewardCalculator>();

// 5. Нарративный агент
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
#### TextGenerator.Service/Properties/launchSettings.json @ 2026-04-07 15:37:13
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
#### TextGenerator.Service/TextGenerator.Service.csproj @ 2026-04-07 15:37:13
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
#### TextGenerator.Service/appsettings.Development.json @ 2026-04-07 15:37:13
```json
{
  "LocalLLM": {
    "ModelPath": "models/llama-3-8b-q4.gguf"
  },
  "OpenAI": {
    "ApiKey": "your-api-key",
    "BaseUrl": "https://api.openai.com/v1/",
    "Model": "gpt-3.5-turbo"
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
#### TextGenerator.Service/appsettings.json @ 2026-04-07 15:37:13
```json
{
  "LocalLLM": {
    "ModelPath": "models/llama-3-8b-q4.gguf"
  },
  "OpenAI": {
    "ApiKey": "your-api-key",
    "BaseUrl": "https://api.openai.com/v1/",
    "Model": "gpt-3.5-turbo"
  },
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
