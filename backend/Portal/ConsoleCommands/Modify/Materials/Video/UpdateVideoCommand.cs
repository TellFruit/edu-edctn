namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Video
{
    internal class UpdateVideoCommand : IConsoleCommand
    {
        private readonly IVideoService _videoService;

        public UpdateVideoCommand(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var userAuth = Program.Root.GetService<IUserAuth>();

            var auth = new AuthorizeCommand(userAuth);
            if (await auth.Run() is false)
            {
                Console.WriteLine("Operation suspended!");
                return true;
            }

            /* Examples of correct input:
             * 1 - Never Gonna Give You Up – 720p, 00:04:12
             * 2 - Invaders Must die - 480p, 00:05:32
             */

            var toCreate = new VideoDTO()
            {
                Id = int.Parse(parameters[0]),
                Title = parameters[1],
                Quality = int.Parse(parameters[2]),
                Duration = TimeSpan.Parse(parameters[3]),
            };

            await _videoService.Create(toCreate);
            Console.WriteLine("Success! Video updated");

            return true;
        }
    }
}
