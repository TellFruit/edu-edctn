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

        private readonly CourseDTO _courseDTO;

        public CreateCourseCommand(ICourseService course)
        {
            _courseDTO = new CourseDTO();
            _course = course;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var basicParser = Program.Root.GetService<IParseInput>();
            var chooseCommand = new ChooseCourseCommand(_courseDTO);

            var commandManager = new CommandManager(basicParser, chooseCommand);

            Console.WriteLine("Course creation flow started. Write commands to form it.");
            await commandManager.InitCommandFlow();

            await _course.Create(_courseDTO);

            return true;
        }
    }
}
