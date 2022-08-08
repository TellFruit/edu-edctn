namespace Portal.UI_Console.ConsoleCommands.Get
{
    internal class GetCoursesCommand : IConsoleCommand
    {
        private readonly ICourseService _courseService;

        public GetCoursesCommand(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var allBooks = await _courseService.GetAll();

            var configService = Program.Root.GetService<IConfigService>();

            IConsoleCommand paginate = new PaginateCommand<CourseDTO>(configService, allBooks);

            await paginate.Run();

            return true;
        }
    }
}
