using Portal.UI_Console.ConsoleCommands.Modify.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseInitCommand : IChooseCommand
    {
        private readonly IConfigService _config;

        public ChooseInitCommand(IConfigService config)
        {
            _config = config;
        }

        public IConsoleCommand Choose(out IParseInput? parser, string commandName)
        {
            parser = null;

            switch (commandName)
            {
                case "create-article":
                    {
                        var articleService = Program.Root.GetService<IArticleService>();

                        parser = new BasicRegexParse(_config.GetSetting("ArticleRegex"));

                        return new CreateArticleCommand(articleService);
                    }
                case "create-course":
                    {
                        var courseService = Program.Root.GetService<ICourseService>();

                        return new CreateCourseCommand(courseService);
                    }
                case "exit":
                    {
                        return new TerminateCommand();
                    }
                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}
