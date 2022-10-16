namespace Portal.UI_Console.ConsoleCommands.Modify.Course
{
    internal class DeleteCourseCommand : IConsoleCommand
    {
        private readonly ICourseService _courseService;
        private readonly UserDTO _userDTO;

        public DeleteCourseCommand(ICourseService courseService, UserDTO userDTO)
        {
            _courseService = courseService;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (await _userDTO.CallAuthCommand() is false)
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
