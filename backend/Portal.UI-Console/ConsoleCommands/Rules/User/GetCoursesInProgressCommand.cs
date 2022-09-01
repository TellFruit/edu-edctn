namespace Portal.UI_Console.ConsoleCommands.Rules.User
{
    internal class GetCoursesInProgressCommand : IConsoleCommand
    {
        private readonly UserDTO _userDTO;

        public GetCoursesInProgressCommand(UserDTO userDTO)
        {
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            //var courses = await _courseService.GetAll();

            //var filtered = courses
            //    .Where(c => _userDTO.CourseProgress
            //        .Select(p => p.CourseId)
            //        .Contains(c.Id));

            var inProgress = _userDTO.CourseProgress
                .Select(c => c.Course);

            Console.WriteLine("All courses ");
            foreach(var course in inProgress)
            {
                Console.WriteLine(course);
            }

            return true;
        }
    }
}
