using TextGenerator.Core.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextGenerator.Core.Models.Interactions.Dialogues;

namespace TextGenerator.Infrastructure.Extensions
{
    public static class DialogueExtensions
    {
        public static void AddChild(this DialogueNode parent, DialogueNode child)
        {
            parent.Childs ??= new List<DialogueNode>();
            if (!parent.Childs.Contains(child))
                parent.Childs.Add(child);
        }

        public static DialogueNode GetDialogueNodeByName(this DialogueNode root, string name)
        {
            if (root == null) throw new ArgumentNullException(nameof(root));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            return GetDialogueNodeByNameRecursive(root, name, 0);
        }

        private static DialogueNode GetDialogueNodeByNameRecursive(DialogueNode node, string name, int currentLevel)
        {
            var targetParts = name.Split('.');
            if (currentLevel >= targetParts.Length) return null;

            string currentPart = targetParts[currentLevel];
            foreach (var child in node.Childs)
            {
                var childParts = child.Name?.Split('.');
                if (childParts != null && childParts.Length > currentLevel && childParts[currentLevel] == currentPart)
                {
                    if (currentLevel + 1 == targetParts.Length)
                        return child;
                    else
                        return GetDialogueNodeByNameRecursive(child, name, currentLevel + 1);
                }
            }
            return null;
        }
    }
}
