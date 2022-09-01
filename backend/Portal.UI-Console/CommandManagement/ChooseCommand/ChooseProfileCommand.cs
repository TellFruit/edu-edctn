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
                        var ruleUser = Program.Root.GetService<IRuleUser>();

                        var userAuth = Program.Root.GetService<IUserAuth>();

                        return new EnrollInCourseCommand(ruleUser, userAuth, _userDTO);
                    }

                case "unenroll-from-course":
                    {
                        var ruleUser = Program.Root.GetService<IRuleUser>();

                        return new UnenrollFromCourseCommand(ruleUser, _userDTO);
                    }

                case "mark-material-learned":
                    {
                        var ruleUser = Program.Root.GetService<IRuleUser>();

                        var userAuth = Program.Root.GetService<IUserAuth>();

                        var courseService = Program.Root.GetService<ICourseService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new MarkMaterialLearnedCommand(ruleUser, userAuth, courseService, _userDTO);
                    }

                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}
