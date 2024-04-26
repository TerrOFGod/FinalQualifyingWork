using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTTextGenerator.Entities.Interfaces.Processors
{
    public interface IAnalyzer
    {
        public bool CheckCorrections(List<string> dialogueBranches);
    }
}
