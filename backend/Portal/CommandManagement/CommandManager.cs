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
            bool allowed = true;
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
                        allowed = await LastCommand.Run();
                    }
                    else
                    {
                        allowed = await LastCommand.Run(_parameterParser.Parse(parts.Last()).ToArray());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            while (allowed);
        }

        public void SetCommandParser(IParseInput parser)
        {
            _commandParser = parser;
        }
    }
}
