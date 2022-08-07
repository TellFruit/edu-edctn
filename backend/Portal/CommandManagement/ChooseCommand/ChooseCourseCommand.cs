using Portal.UI_Console.ConsoleCommands.Modify.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseCourseCommand : IChooseCommand
    {
        private readonly IConfigService _config;
        private readonly CourseDTO _toCreate;

        public ChooseCourseCommand(IConfigService config, CourseDTO toCreate)
        {
            _config = config;
            _toCreate = toCreate;
        }

        public IConsoleCommand Choose(out IParseInput? parser, string commandName)
        {
            parser = null;

            switch (commandName)
            {
                case "add-article":
                    {
                       var articleService = Program.Root.GetService<IArticleService>();

                        return new AddArticleCommand(articleService, _toCreate);
                    }
                case "return":
                    {
                        return new ExitFlowCommand();
                    }
                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}
