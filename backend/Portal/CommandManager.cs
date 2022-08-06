using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console
{
    internal class CommandManager : ICommandManager
    {
        public IConsoleCommand? GetCommand(string commandName)
        {
            throw new NotImplementedException();
        }

        public void InitCommandFlow()
        {
            throw new NotImplementedException();
        }

        public void SetCommandParser(IParseInput parser)
        {
            throw new NotImplementedException();
        }
    }
}
