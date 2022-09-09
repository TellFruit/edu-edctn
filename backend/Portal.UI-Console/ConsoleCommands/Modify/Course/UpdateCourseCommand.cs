namespace Portal.UI_Console.ConsoleCommands.Modify.Course
{
    internal class UpdateCourseCommand : IConsoleCommand
    {
        private readonly ICourseService _course;
        private readonly UserDTO _userDTO;

        public UpdateCourseCommand(ICourseService course, UserDTO userDTO)
        {
            _course = course;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            if (await _userDTO.CallAuthCommand() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            var courseDTO = await _course.GetById(int.Parse(parameters[0]));

            if (courseDTO is null)
            {
                return true;
            }

            var basicParser = Program.Root.GetRequiredService<IParseInput>();
            var chooseCommand = new ChooseFormCourseCommand(courseDTO);

            var commandManager = new CommandManager(basicParser, chooseCommand);

            Console.WriteLine("Course update flow started. Write commands to update it.");
            await commandManager.InitCommandFlow();

            if (courseDTO.Materials.Count > 0
                && courseDTO.Perks.Count > 0)
            {
                await _course.Update(courseDTO);
                Console.WriteLine("Success! Course updated.");
            }
            else
            {
                Console.WriteLine("Operation failed.");
            }

            return true;
        }
    }
}
