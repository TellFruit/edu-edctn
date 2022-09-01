namespace Portal.UI_Console.ConsoleCommands.Rules.User
{
    internal class VIewCourseProgressCommand : IConsoleCommand
    {
        private readonly ICourseService _courseService;
        private readonly UserDTO _userDTO;

        public VIewCourseProgressCommand(IUserAuth userAuth, ICourseService courseService, UserDTO userDTO)
        {
            _courseService = courseService;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var wantedId = int.Parse(parameters[0]);

            var course = await _courseService.GetById(wantedId);

            var courseProgress = _userDTO.CourseProgress
                    .FirstOrDefault(c => c.CourseId.Equals(wantedId));

            string input = string.Empty;
            do
            {
                Console.WriteLine("Course info:");
                Console.WriteLine(course);
                Console.WriteLine($"Course progress: {courseProgress.Progress}%");

                Console.WriteLine();

                var learnedMaterials = course.Materials
                    .Where(m => _userDTO.MaterialLearned
                        .Select(ml => ml.MaterialId)
                            .Contains(m.Id));

                var materialsLeft = course.Materials
                    .Where(m => _userDTO.MaterialLearned
                        .Select(ml => ml.MaterialId)
                            .Contains(m.Id) is false);

                Console.WriteLine("List of learned materials:");
                Console.WriteLine("-");
                foreach (var material in learnedMaterials)
                {
                    Console.WriteLine(material);
                }

                Console.WriteLine("List of materials left to learn:");
                Console.WriteLine("-");
                foreach (var material in materialsLeft)
                {
                    Console.WriteLine(material);
                }

                var basicParser = Program.Root.GetService<IParseInput>();

                var chooseCommand = new ChooseCourseProgressCommand(_userDTO, course);

                var launch = new LaunchManagerCommand(chooseCommand, basicParser);

                await launch.Run();

                Console.WriteLine("Proceed? If not, type \'no\'");

                input = Console.ReadLine();

                if (input.Equals("no"))
                {
                    return true;
                }
            } 
            while (true);
        }
    }
}
