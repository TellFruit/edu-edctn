namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseFormCourseCommand : IChooseCommand
    {
        private readonly CourseDTO _courseDTO;

        public ChooseFormCourseCommand(CourseDTO courseDTO)
        {
            _courseDTO = courseDTO;
        }

        public IConsoleCommand Choose(out IParseInput? parser, string commandName)
        {
            parser = null;

            switch (commandName)
            {
                case "add-article":
                    {
                        var articleService = Program.Root.GetRequiredService<IArticleService>();

                        return new AddArticleCommand(articleService, _courseDTO);
                    }

                case "add-book":
                    {
                        var bookService = Program.Root.GetRequiredService<IBookService>();

                        return new AddBookCommand(bookService, _courseDTO);
                    }

                case "add-video":
                    {
                        var videoService = Program.Root.GetRequiredService<IVideoService>();

                        return new AddVideoCommand(videoService, _courseDTO);
                    }

                case "add-perk":
                    {
                        var perkService = Program.Root.GetRequiredService<IPerkService>();

                        return new AddPerkCommand(perkService, _courseDTO);
                    }

                case "remove-article":
                    {
                        return new RemoveArticleCommand(_courseDTO);
                    }

                case "remove-book":
                    {
                        return new RemoveBookCommand(_courseDTO);
                    }

                case "remove-video":
                    {
                        return new RemoveVideoCommand(_courseDTO);
                    }

                case "remove-perk": 
                    {
                        return new RemovePerkCommand(_courseDTO);
                    }

                case "finish-course":
                    {
                        return new FinishCourseCreationCommand(_courseDTO);
                    }

                case "return":
                    {
                        return new CancelCourseCreateCommand(_courseDTO);
                    }

                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}
