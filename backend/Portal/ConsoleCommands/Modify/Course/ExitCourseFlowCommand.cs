namespace Portal.UI_Console.ConsoleCommands.Modify.Course
{
    internal class CancelCourseCreateCommand : ExitFlowCommand
    {
        private readonly CourseDTO _courseDTO;

        public CancelCourseCreateCommand(CourseDTO courseDTO)
        {
            _courseDTO = courseDTO;
            ClearBeforeDeletion();
        }

        private void ClearBeforeDeletion()
        {
            _courseDTO.Materials.Clear();
        }
    }
}
