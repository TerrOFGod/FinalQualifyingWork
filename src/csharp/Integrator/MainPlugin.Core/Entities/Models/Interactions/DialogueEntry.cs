using MainPlugin.Core.Entities.Interfaces;
using MainPlugin.Core.Entities.Models.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Models.Interactions
{
    public class DialogueEntry : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public string Text { get; set; }

        public List<DialogueNode> Childs { get; set; }
    }
}
