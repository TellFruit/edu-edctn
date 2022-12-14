namespace Portal.UI_Console.ConsoleCommands.Rules.User
{
    internal class UnenrollFromCourseCommand : IConsoleCommand
    {
        private readonly IRuleUser _ruleUser;
        private readonly UserDTO _userDTO;

        public UnenrollFromCourseCommand(IRuleUser ruleUser, UserDTO userDTO)
        {
            _ruleUser = ruleUser;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            bool toContinue = false;
            Console.WriteLine("All courses you have yet to finish: ");
            foreach (var progress in _userDTO.CourseProgress)
            {
                if (progress.CourseFinished is false)
                {
                    toContinue = true;
                    Console.WriteLine(progress);
                }
            }

            if (!toContinue)
            {
                Console.WriteLine("No courses attended! Returning...");
                return true;
            }

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
                    var res = await _ruleUser.Unenroll(_userDTO.Id, wantedId);

                    _userDTO.CourseProgress = res.CourseProgress;

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true);

            Console.WriteLine("Success! You unerolled from that course.");

            return true;
        }
    }
}
