using Portal.UI_Console.ConsoleCommands.Modify.Skills;

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

                case "create-book":
                    {
                        var bookService = Program.Root.GetService<IBookService>();

                        parser = new BasicRegexParse(_config.GetSetting("BookRegex"));

                        return new CreateBookCommand(bookService);
                    }

                case "create-video":
                    {
                        var videoService = Program.Root.GetService<IVideoService>();

                        parser = new BasicRegexParse(_config.GetSetting("VideoRegex"));

                        return new CreateVideoCommand(videoService);
                    }

                case "create-course":
                    {
                        var courseService = Program.Root.GetService<ICourseService>();

                        return new CreateCourseCommand(courseService);
                    }

                case "create-perk":
                    {
                        var perkService = Program.Root.GetService<IPerkService>();

                        parser = new BasicSplitParse("");

                        return new CreatePerkCommand(perkService);
                    }

                case "get-articles":
                    {
                        var articleService = Program.Root.GetService<IArticleService>();

                        return new GetArticlesCommand(articleService);
                    }

                case "get-books":
                    {
                        var bookService = Program.Root.GetService<IBookService>();

                        return new GetBooksCommand(bookService);
                    }

                case "get-videos":
                    {
                        var videoService = Program.Root.GetService<IVideoService>();

                        return new GetVideosCommand(videoService);
                    }

                case "get-courses":
                    {
                        var courseService = Program.Root.GetService<ICourseService>();

                        return new GetCoursesCommand(courseService);
                    }

                case "get-perks":
                    {
                        var perkService = Program.Root.GetService<IPerkService>();

                        return new GetPerksCommand(perkService);
                    }

                case "update-article":
                    {
                        var articleService = Program.Root.GetService<IArticleService>();

                        parser = new BasicRegexParse(_config.GetSetting("ModifyArticleRegex"));

                        return new UpdateArticleCommand(articleService);
                    }

                case "update-book":
                    {
                        var bookService = Program.Root.GetService<IBookService>();

                        parser = new BasicRegexParse(_config.GetSetting("ModifyBookRegex"));

                        return new UpdateBookCommand(bookService);
                    }

                case "update-video":
                    {
                        var videoService = Program.Root.GetService<IVideoService>();

                        parser = new BasicRegexParse(_config.GetSetting("ModifyVideoRegex"));

                        return new UpdateVideoCommand(videoService);
                    }

                case "update-course":
                    {
                        var courseService = Program.Root.GetService<ICourseService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new UpdateCourseCommand(courseService);
                    }

                case "update-perk":
                    {
                        var perkService = Program.Root.GetService<IPerkService>();

                        parser = new BasicRegexParse(_config.GetSetting("ModifyPerkRegex"));

                        return new UpdatePerkCommand(perkService);
                    }

                case "delete-article":
                    {
                        var articleService = Program.Root.GetService<IArticleService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new DeleteArticleCommand(articleService);
                    }

                case "delete-book":
                    {
                        var bookService = Program.Root.GetService<IBookService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new DeleteBookCommand(bookService);
                    }

                case "delete-video":
                    {
                        var videoService = Program.Root.GetService<IVideoService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new DeleteVideoCommand(videoService);
                    }

                case "delete-course":
                    {
                        var courseService = Program.Root.GetService<ICourseService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new DeleteCourseCommand(courseService);
                    }

                case "delete-perk":
                    {
                        var perkService = Program.Root.GetService<IPerkService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new DeletePerkCommand(perkService);
                    }

                case "logout":
                    {
                        var userAuth = Program.Root.GetService<IUserAuth>();

                        return new LogoutCommand(userAuth);
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
