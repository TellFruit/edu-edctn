﻿namespace Portal.UI_Console.ConsoleCommands.Modify.Course
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
            var userAuth = Program.Root.GetRequiredService<IUserAuth>();

            var auth = new AuthorizeCommand(userAuth);
            if (await auth.Run() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            var basicParser = Program.Root.GetRequiredService<IParseInput>();
            var chooseCommand = new ChooseFormCourseCommand(_courseDTO);

            var commandManager = new CommandManager(basicParser, chooseCommand);

            Console.WriteLine("Course creation flow started. Write commands to form it.");
            await commandManager.InitCommandFlow();

            if (_courseDTO.Materials.Count > 0)
            {
                await _course.Create(_courseDTO);
                Console.WriteLine("Success! Course created.");
            }
            else
            {
                Console.WriteLine("Operation failed. No materials are present!");
            }

            return true;
        }
    }
}
