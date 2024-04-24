using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin.Core.Entities.Interfaces;
public interface IPlugin
{
    string Name { get; }
    string Description { get; }
    void GenerateQuest();
}

