namespace Portal.UI_Console.ConsoleCommands.Get
{
    internal class GetVideosCommand : IConsoleCommand
    {
        private readonly IVideoService _videoService;

        public GetVideosCommand(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var all = await _videoService.GetAll();

            var configService = Program.Root.GetService<IConfigService>();

            IConsoleCommand paginate = new PaginateCommand<VideoDTO>(configService, all);

            await paginate.Run();

            return true;
        }
    }
}
