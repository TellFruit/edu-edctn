namespace Portal.UI_Console.ConsoleCommands.Rules.User
{
    internal class GetFinishedCoursesCommand : IConsoleCommand
    {
        private readonly UserDTO _userDTO;

        public GetFinishedCoursesCommand(UserDTO userDTO)
        {
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var finished = _userDTO.CourseProgress
                .Where(c => c.CourseFinished)
                .Select(c => c.Course);

            Console.WriteLine("You have finished these courses: ");
            foreach (var course in finished)
            {
                Console.WriteLine(course);
            }

            return true;
        }
    }
}
