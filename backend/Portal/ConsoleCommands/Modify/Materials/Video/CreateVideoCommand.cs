namespace Portal.UI_Console.ConsoleCommands.Modify.Materials.Video
{
    internal class CreateVideoCommand : IConsoleCommand
    {
        private readonly IVideoService _videoService;

        public CreateVideoCommand(IVideoService videoService)
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
             * Never Gonna Give You Up – 720p, 00:04:12
             * Invaders Must die - 480p, 00:05:32
             */

            var toCreate = new VideoDTO()
            {
                Title = parameters[0],
                Quality = int.Parse(parameters[1]),
                Duration = TimeSpan.Parse(parameters[2]),
            };

            await _videoService.Create(toCreate);
            Console.WriteLine("Success! Video created");

            return true;
        }
    }
}
