namespace Portal.UI_Console.ConsoleCommands.Rules.User
{
    internal class EnrollInCourseCommand : IConsoleCommand
    {
        private readonly IRuleUser _ruleUser;
        private readonly IUserAuth _userAuth;

        public EnrollInCourseCommand(IRuleUser ruleUser, IUserAuth userAuth)
        {
            _ruleUser = ruleUser;
            _userAuth = userAuth;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var courseService = Program.Root.GetService<ICourseService>();

            var getCourses = new GetCoursesCommand(courseService);

            await getCourses.Run();

            int wantedId = 0;
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
                    await _ruleUser.Enroll(_userAuth.LoggedId, wantedId);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true);

            return true;
        }
    }
}
