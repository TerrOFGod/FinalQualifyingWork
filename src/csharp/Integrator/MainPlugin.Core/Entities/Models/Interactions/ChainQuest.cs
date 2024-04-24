using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainPlugin.Core.Entities.Interfaces;

namespace MainPlugin.Core.Entities.Models.Interactions
{
    public class ChainQuest : IBase
    {
        public int Id => ChainQuestId;
        public int ChainQuestId { get; set; }
    }
}
