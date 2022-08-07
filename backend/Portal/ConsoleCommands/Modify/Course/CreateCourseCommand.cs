using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Course
{
    internal class CreateCourseCommand : IConsoleCommand
    {
        private readonly ICourseService _course;
        private readonly IArticleService _article;

        public async Task<bool> Output(params string[] parameters)
        {

        }
    }
}
