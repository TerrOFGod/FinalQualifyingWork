using MainPlugin.Core.Entities.Interfaces;
using MainPlugin.Core.Entities.Models.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Models.Actions
{
    public class SocialConnection : IBase
    {
        public int ID { get; set; }

        public int Id => ID;

        public SmartNPC RelatedNPC { get; set; }

        public string Type { get; set; }
        public string Relationships { get; set; }
    }
}
