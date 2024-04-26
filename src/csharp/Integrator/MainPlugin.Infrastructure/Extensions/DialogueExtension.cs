using GPTTextGenerator.Entities.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GPTTextGenerator.Infrastructure.Extensions
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
