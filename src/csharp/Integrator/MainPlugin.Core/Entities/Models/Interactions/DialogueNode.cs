using MainPlugin.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Models.Interactions
{
    public class DialogueNode : IBase
    {
        public int Id => ID;
        public int ID { get; set; }
        public string InterlocutorNPC { get; set; }
        public string InterlocutorPlayer { get; set; }
        public string Name { get; set; }
        public string NPCText { get; set; }
        public string PlayerText { get; set; }
        public List<DialogueNode> Childs { get; set; }
    }
}
