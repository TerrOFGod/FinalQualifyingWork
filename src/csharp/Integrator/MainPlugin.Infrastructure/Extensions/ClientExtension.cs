using GPTTextGenerator.Entities.Models.Interactions;
using GPTTextGenerator.Entities.Models.Interactors;
using GPTTextGenerator.Infrastructure.API;
using GPTTextGenerator.Infrastructure.Helpers;

namespace GPTTextGenerator.Infrastructure.Extensions
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
