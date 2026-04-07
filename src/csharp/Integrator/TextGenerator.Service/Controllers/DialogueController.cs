using Microsoft.AspNetCore.Mvc;
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