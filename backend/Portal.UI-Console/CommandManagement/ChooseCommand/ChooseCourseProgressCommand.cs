namespace Portal.UI_Console.CommandManagement.ChooseCommand
{
    internal class ChooseCourseProgressCommand : IChooseCommand
    {
        private readonly UserDTO _userDTO;
        private readonly CourseDTO _courseDTO;

        public ChooseCourseProgressCommand(UserDTO userDTO, CourseDTO courseDTO)
        {
            _userDTO = userDTO;
            _courseDTO = courseDTO;
        }

        public IConsoleCommand Choose(out IParseInput? parser, string commandName)
        {
            parser = null;

            switch (commandName)
            {
                case "mark-mat-learned":
                    {
                        var ruleUser = Program.Root.GetService<IRuleUser>();

                        parser = new BasicSplitParse(string.Empty);

                        return new MarkMaterialLearnedCommand(ruleUser, _userDTO, _courseDTO);
                    }

                case "unmark-mat-learned":
                    {
                        var ruleUser = Program.Root.GetService<IRuleUser>();

                        parser = new BasicSplitParse(string.Empty);

                        return new UnmarkMaterialLearnedCommand(ruleUser, _userDTO, _courseDTO);
                    }

                default:
                    break;
            }

            throw new InvalidOperationException(nameof(commandName));
        }
    }
}
