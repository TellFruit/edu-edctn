namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseProfileCommand : IChooseCommand
    {
        private readonly UserDTO _userDTO;

        public ChooseProfileCommand(UserDTO userDTO)
        {
            _userDTO = userDTO;
        }

        public IConsoleCommand Choose(out IParseInput? parser, string commandName)
        {
            parser = null;

            switch(commandName)
            {
                case "enroll-in-course":
                    {
                        var ruleUser = Program.Root.GetRequiredService<IRuleUser>();

                        var userAuth = Program.Root.GetRequiredService<IUserAuth>();

                        return new EnrollInCourseCommand(ruleUser, userAuth, _userDTO);
                    }

                case "unenroll-from-course":
                    {
                        var ruleUser = Program.Root.GetRequiredService<IRuleUser>();

                        return new UnenrollFromCourseCommand(ruleUser, _userDTO);
                    }

                case "get-courses-in-progress":
                    {
                        return new GetCoursesInProgressCommand(_userDTO);
                    }

                case "get-finished-courses":
                    {
                        return new GetFinishedCoursesCommand(_userDTO);
                    }

                case "get-mat-learned":
                    {
                        return new GetLearnedMaterialsCommand(_userDTO);
                    }

                case "get-perks-level":
                    {
                        return new GetPerksLevelCommand(_userDTO);
                    }

                case "view-course-progress":
                    {
                        var courseService = Program.Root.GetRequiredService<ICourseService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new VIewCourseProgressCommand(courseService, _userDTO);
                    }

                case "logout":
                    {
                        var userAuth = Program.Root.GetRequiredService<IUserAuth>();

                        return new LogoutCommand(userAuth, false, _userDTO);
                    }

                case "return":
                    {
                        return new ExitFlowCommand();
                    }

                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}
