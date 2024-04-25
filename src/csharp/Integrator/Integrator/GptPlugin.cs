using MainPlugin.Core.Entities.Models.Interactors;
using MainPlugin.Infrastructure.Helpers;
using System;

namespace Integrator;

public class GptPlugin
{
    private string apiKey;
    private string apiUrl;

    public GptPlugin(string apiKey, string apiUrl)
    {
        this.apiKey = apiKey;
        this.apiUrl = apiUrl;
    }

    public string GenerateText(string prompt)
    {
        //SmartNPC npc = new SmartNPC();
        //npc.GenerateBasicBranchedDialogueRequest(2,3);
        // Ваш код для обращения к API GPT и генерации текста
        return "Сгенерированный текст";
    }
}