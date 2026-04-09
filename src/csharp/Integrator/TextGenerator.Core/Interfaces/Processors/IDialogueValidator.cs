using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator.Core.Interfaces.Processors
{
    /// <summary>
    /// Проверка корректности сгенерированных диалогов (синтаксис, логика).
    /// </summary>
    public interface IDialogueValidator
    {
        /// <summary>Проверить список веток диалога на корректность.</summary>
        public bool CheckCorrections(List<string> dialogueBranches);
    }
}
