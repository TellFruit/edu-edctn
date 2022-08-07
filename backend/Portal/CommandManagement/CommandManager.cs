using Portal.UI_Console.ConsoleCommands.Modify.Materials.Article;

namespace Portal.UI_Console.CommandManagement
{
    internal class CommandManager : ICommandManager
    {
        private readonly IChooseCommand _choose;

        private IParseInput _commandParser;
        private IParseInput? _parameterParser;

        public IConsoleCommand LastCommand { get; set; }

        public CommandManager(IParseInput commandParser, IChooseCommand choose)
        {
            _commandParser = commandParser;
            _choose = choose;
        }

        public IConsoleCommand GetCommand(string commandName)
        {
            return _choose.Choose(out _parameterParser, commandName);
        }

        public async Task InitCommandFlow()
        {
            string input = "";

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
