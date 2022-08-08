using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Modify.Course
{
    internal class DeleteCourseCommand : IConsoleCommand
    {
        private readonly ICourseService _courseService;

        public DeleteCourseCommand(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var userAuth = Program.Root.GetService<IUserAuth>();

            var auth = new AuthorizeCommand(userAuth);
            if (await auth.Run() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            await _courseService.Delete(int.Parse(parameters[0]));
            Console.WriteLine("Success! Course deleted");

            return true;
        }
    }
}
