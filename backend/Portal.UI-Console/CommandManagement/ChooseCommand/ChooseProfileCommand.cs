﻿namespace Portal.UI_Console.CommandManagement.ChooseCommand
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

                case "get-in-progress":
                    {
                        return new GetCoursesInProgressCommand(_userDTO);
                    }

                case "get-finished":
                    {
                        return new GetFinishedCoursesCommand(_userDTO);
                    }

                case "view-course-progress":
                    {
                        var courseService = Program.Root.GetService<ICourseService>();

                        parser = new BasicSplitParse(string.Empty);

                        return new VIewCourseProgressCommand(courseService, _userDTO);
                    }

                case "logout":
                    {
                        var userAuth = Program.Root.GetService<IUserAuth>();

                        return new LogoutCommand(userAuth, false);
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
