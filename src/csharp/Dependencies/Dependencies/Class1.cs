using System;
using System.Threading.Tasks;
using GPTTextGenerator.Entities;
using GPTTextGenerator.Entities.Models.Interactions;
using GPTTextGenerator.Entities.Models.Interactors;
using GPTTextGenerator.Infrastructure;
using GPTTextGenerator.Infrastructure.API;
using GPTTextGenerator.Infrastructure.Extensions;
using GPTTextGenerator.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dependencies
{
    public class Class1
    {
        public async Task Test()
        {
            SmartNPC npc = new SmartNPC();

            GptApiClient client = new GptApiClient("", "https://api.vsegpt.ru/v1/", "anthropic/claude-3-haiku");

            DialogueEntry branchedDialogue;

            do
            {
                branchedDialogue = await client.GenerateDialogueTree(npc, 2, 2);
            } while (!branchedDialogue.GetAllDialogueBranches().CheckDialogueCorrection());

            throw new Exception();
        }
    }
}
