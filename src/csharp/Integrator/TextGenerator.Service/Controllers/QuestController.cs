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