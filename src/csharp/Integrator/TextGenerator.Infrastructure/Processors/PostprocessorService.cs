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
    
    public DialogueEntry ParseBranchedDialogueResponse(SmartNPC npc, string rawResponse)
        => _responseParser.ParseBranchedDialogueResponse(npc, rawResponse).GetAwaiter().GetResult();

    public DialogueNode ParseSteppedDialogueResponse(SmartNPC npc, string rawResponse)
        => _responseParser.ParseSteppedDialogueResponse(npc, rawResponse).GetAwaiter().GetResult();

    public Quest ParseQuestResponse(string rawResponse)
        => _responseParser.ParseQuestResponse(rawResponse).GetAwaiter().GetResult();
    
    // Obsolete методы для обратной совместимости
    [Obsolete("Use ParseBranchedDialogueResponse")]
    public DialogueEntry DecodeAPIBranchedDialogueResponse(SmartNPC npc, string response) 
        => ParseBranchedDialogueResponse(npc, response);
    
    [Obsolete("Use ParseSteppedDialogueResponse")]
    public DialogueNode DecodeSingleStepDialogueResponse(SmartNPC npc, string response) 
        => ParseSteppedDialogueResponse(npc, response);
    
    [Obsolete("Use ParseQuestResponse")]
    public Quest ParseQuest(string response) => ParseQuestResponse(response);
}