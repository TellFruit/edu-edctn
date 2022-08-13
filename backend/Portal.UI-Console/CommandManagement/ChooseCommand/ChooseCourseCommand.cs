namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseCourseCommand : IChooseCommand
    {
        private readonly CourseDTO toCreate;

        public ChooseCourseCommand(CourseDTO toCreate)
        {
            this.toCreate = toCreate;
        }

        public IConsoleCommand Choose(out IParseInput? parser, string commandName)
        {
            parser = null;

            switch (commandName)
            {
                case "add-article":
                    {
                        var articleService = Program.Root.GetService<IArticleService>();

                        return new AddArticleCommand(articleService, toCreate);
                    }

                case "add-book":
                    {
                        var bookService = Program.Root.GetService<IBookService>();

                        return new AddBookCommand(bookService, toCreate);
                    }

                case "add-video":
                    {
                        var videoService = Program.Root.GetService<IVideoService>();

                        return new AddVideoCommand(videoService, toCreate);
                    }

                case "remove-article":
                    {
                        return new RemoveArticleCommand(toCreate);
                    }

                case "remove-book":
                    {
                        return new RemoveBookCommand(toCreate);
                    }

                case "remove-video":
                    {
                        return new RemoveVideoCommand(toCreate);
                    }

                case "finish-course":
                    {
                        return new FinishCourseCreationCommand(toCreate);
                    }

                case "return":
                    {
                        return new CancelCourseCreateCommand(toCreate);
                    }

                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}
