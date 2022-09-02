namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseCatalogCommand : IChooseCommand
    {
        private readonly IConfigService _config;

        public ChooseCatalogCommand(IConfigService config)
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
                        var articleService = Program.Root.GetRequiredService<IArticleService>();

                        parser = new BasicRegexParse(_config.GetSetting("ArticleRegex"));

                        return new CreateArticleCommand(articleService);
                    }

                case "create-book":
                    {
                        var bookService = Program.Root.GetRequiredService<IBookService>();

                        parser = new BasicRegexParse(_config.GetSetting("BookRegex"));

                        return new CreateBookCommand(bookService);
                    }

                case "create-video":
                    {
                        var videoService = Program.Root.GetRequiredService<IVideoService > ();

                        parser = new BasicRegexParse(_config.GetSetting("VideoRegex"));

                        return new CreateVideoCommand(videoService);
                    }

                case "create-course":
                    {
                        var courseService = Program.Root.GetRequiredService<ICourseService>();

                        return new CreateCourseCommand(courseService);
                    }

                case "create-perk":
                    {
                        var perkService = Program.Root.GetRequiredService<IPerkService>();

                        parser = new BasicSplitParse("");

                        return new CreatePerkCommand(perkService);
                    }

                case "get-articles":
                    {
                        var articleService = Program.Root.GetRequiredService<IArticleService>();

                        return new GetArticlesCommand(articleService);
                    }

                case "get-books":
                    {
                        var bookService = Program.Root.GetRequiredService<IBookService>();

                        return new GetBooksCommand(bookService);
                    }

                case "get-videos":
                    {
                        var videoService = Program.Root.GetRequiredService<IVideoService > ();

                        return new GetVideosCommand(videoService);
                    }

                case "get-courses":
                    {
                        var courseService = Program.Root.GetRequiredService<ICourseService>();

                        return new GetCoursesCommand(courseService);
                    }

                case "get-perks":
                    {
                        var perkService = Program.Root.GetRequiredService<IPerkService>();

                        return new GetPerksCommand(perkService);
                    }

                case "update-article":
                    {
                        var articleService = Program.Root.GetRequiredService<IArticleService>();

                        parser = new BasicRegexParse(_config.GetSetting("ModifyArticleRegex"));

                        return new UpdateArticleCommand(articleService);
                    }

                case "update-book":
                    {
                        var bookService = Program.Root.GetRequiredService<IBookService>();

                        parser = new BasicRegexParse(_config.GetSetting("ModifyBookRegex"));

                        return new UpdateBookCommand(bookService);
                    }

                case "update-video":
                    {
                        var videoService = Program.Root.GetRequiredService<IVideoService>();

                        parser = new BasicRegexParse(_config.GetSetting("ModifyVideoRegex"));

                        return new UpdateVideoCommand(videoService);
                    }

                case "update-course":
                    {
                        var courseService = Program.Root.GetRequiredService<ICourseService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new UpdateCourseCommand(courseService);
                    }

                case "update-perk":
                    {
                        var perkService = Program.Root.GetRequiredService<IPerkService>();

                        parser = new BasicRegexParse(_config.GetSetting("ModifyPerkRegex"));

                        return new UpdatePerkCommand(perkService);
                    }

                case "delete-article":
                    {
                        var articleService = Program.Root.GetRequiredService<IArticleService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new DeleteArticleCommand(articleService);
                    }

                case "delete-book":
                    {
                        var bookService = Program.Root.GetRequiredService<IBookService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new DeleteBookCommand(bookService);
                    }

                case "delete-video":
                    {
                        var videoService = Program.Root.GetRequiredService<IVideoService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new DeleteVideoCommand(videoService);
                    }

                case "delete-course":
                    {
                        var courseService = Program.Root.GetRequiredService<ICourseService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new DeleteCourseCommand(courseService);
                    }

                case "delete-perk":
                    {
                        var perkService = Program.Root.GetRequiredService<IPerkService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new DeletePerkCommand(perkService);
                    }

                case "logout":
                    {
                        var userAuth = Program.Root.GetRequiredService<IUserAuth>();

                        return new LogoutCommand(userAuth, true);
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
