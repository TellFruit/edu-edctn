using Portal.UI_Console.ConsoleCommands.Get;
using Portal.UI_Console.ConsoleCommands.Modify.Course;
using Portal.UI_Console.ConsoleCommands.Modify.Materials.Book;
using Portal.UI_Console.ConsoleCommands.Modify.Materials.Video;
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
                case "get-articles":
                    {
                        var articleService = Program.Root.GetService<IArticleService>();

                        return new GetArticlesCommand(articleService);
                    }
                case "get-courses":
                    {
                        var courseService = Program.Root.GetService<ICourseService>();

                        return new GetCoursesCommand(courseService);
                    }
                case "update-article":
                    {
                        var articleService = Program.Root.GetService<IArticleService>();

                        parser = new BasicRegexParse(_config.GetSetting("ModifyArticleRegex"));

                        return new UpdateArticleCommand(articleService);
                    }
                case "delete-article":
                    {
                        var articleService = Program.Root.GetService<IArticleService>();

                        parser = new BasicSplitParse("");

                        return new DeleteArticleCommand(articleService);
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
