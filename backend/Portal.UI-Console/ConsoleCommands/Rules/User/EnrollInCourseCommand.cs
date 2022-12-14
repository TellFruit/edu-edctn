namespace Portal.UI_Console.ConsoleCommands.Rules.User
{
    internal class EnrollInCourseCommand : IConsoleCommand
    {
        private readonly IRuleUser _ruleUser;
        private readonly IUserAuth _userAuth;
        private readonly UserDTO _userDTO;

        public EnrollInCourseCommand(IRuleUser ruleUser, IUserAuth userAuth, UserDTO userDTO)
        {
            _ruleUser = ruleUser;
            _userAuth = userAuth;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var courseService = Program.Root.GetRequiredService<ICourseService>();

            var getCourses = new GetCoursesCommand(courseService);

            await getCourses.Run();

            int wantedId = default;
            string input = string.Empty;
            do
            {
                Console.WriteLine("Write id of wanted course or \'return\' to stop: ");

                input = Console.ReadLine();

                if (input.Equals("return"))
                {
                    return true;
                }

                try
                {
                    wantedId = int.Parse(input);
                }
                catch
                {
                    if (!input.Equals(string.Empty))
                    {
                        input = string.Empty;
                        continue;
                    }
                }

                try
                {
                    var res = await _ruleUser.Enroll(_userDTO.Id, wantedId);

                    _userDTO.CourseProgress = res.CourseProgress;
                    _userDTO.PerkLevel = res.PerkLevel;

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true);

            Console.WriteLine("Success! You enrolled in that course");

            return true;
        }
    }
}
