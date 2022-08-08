﻿namespace Portal.UI_Console.ConsoleCommands.Modify.Course
{
    internal class FinishCourseCreationCommand : IConsoleCommand
    {
        private readonly CourseDTO _courseDTO;

        public FinishCourseCreationCommand(CourseDTO courseDTO)
        {
            _courseDTO = courseDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (_courseDTO.Materials.Count < 0)
            {
                Console.WriteLine("Add materials first!");
                return true;
            }

            string input = "";

            Console.WriteLine("Write name of the course: ");
            input = Console.ReadLine();
            _courseDTO.Name = input;

            Console.WriteLine("Write description of the course: ");
            input = Console.ReadLine();
            _courseDTO.Description = input;

            return false;
        }
    }
}
