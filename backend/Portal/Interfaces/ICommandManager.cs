using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.Interfaces
{
    internal interface ICommandManager
    {
        void InitCommandFlow();

        void SetCommandParser(IParseInput parser);

        IConsoleCommand? GetCommand(string commandName);
    }
}
