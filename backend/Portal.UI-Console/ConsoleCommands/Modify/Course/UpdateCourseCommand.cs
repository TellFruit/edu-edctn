namespace Portal.UI_Console.ConsoleCommands.Modify.Course
{
    internal class UpdateCourseCommand : IConsoleCommand
    {
        private readonly ICourseService _course;

        public UpdateCourseCommand(ICourseService course)
        {
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
