using Portal.UI_Console.ConsoleCommands.Modify.Course;
using Portal.UI_Console.ConsoleCommands.Modify.Course.Add;
using Portal.UI_Console.ConsoleCommands.Modify.Course.Remove;

namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseCourseCommand : IChooseCommand
    {
        private readonly CourseDTO _toCreate;

        public ChooseCourseCommand(CourseDTO toCreate)
        {
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
                case "remove-article":
                    {
                        return new RemoveArticleCommand(_toCreate);
                    }
                case "finish-course":
                    {
                        return new FinishCourseCreationCommand(_toCreate);
                    }
                case "return":
                    {
                        return new CancelCourseCreateCommand(_toCreate);
                    }
                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}
