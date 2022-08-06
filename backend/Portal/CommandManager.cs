using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console
{
    internal class CommandManager : ICommandManager
    {
        private readonly IConfigService _config;

        private IParseInput _commandParser;
        private IParseInput? _parameterParser;

        public IConsoleCommand? LastCommand { get; set; }

        public CommandManager(IParseInput commandParser, IConfigService config)
        {
            _commandParser = commandParser;
            _config = config;
        }

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
