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