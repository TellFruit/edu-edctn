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
