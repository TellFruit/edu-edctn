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
            
        }

        public async Task InitCommandFlow()
        {
            string input;

            do
            {
                try
                {
                    input = Console.ReadLine() ?? "";

                    var parts = _commandParser.Parse(input);

                    LastCommand = GetCommand(parts.First());

                    if (_parameterParser is null)
                    {
                        await LastCommand.Output();
                    }
                    else
                    {
                        await LastCommand.Output(_parameterParser.Parse(parts.Last()).ToArray());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            while (true);
        }

        public void SetCommandParser(IParseInput parser)
        {
            _commandParser = parser;
        }
    }
}
