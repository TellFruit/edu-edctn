using Portal.UI_Console.ConsoleCommands.Modify.Materials.Article;

namespace Portal.UI_Console.CommandManagement
{
    internal class CommandManager : ICommandManager
    {
        private readonly IConfigService _config;

        private IParseInput _commandParser;
        private IParseInput? _parameterParser;

        public IConsoleCommand LastCommand { get; set; }

        public CommandManager(IParseInput commandParser, IConfigService config)
        {
            _commandParser = commandParser;
            _config = config;
        }

        public IConsoleCommand GetCommand(string commandName)
        {
            _parameterParser = null;

            switch (commandName)
            {
                case "create-article":
                    {
                        var articleService = Program.Root.GetService<IArticleService>();

                        _parameterParser = new BasicRegexParse(_config.GetSetting("ArticleRegex"));

                        return new CreateArticleCommand(articleService);
                    }
                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
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
