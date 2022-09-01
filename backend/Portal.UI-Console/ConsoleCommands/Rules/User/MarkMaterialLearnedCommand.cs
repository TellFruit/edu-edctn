namespace Portal.UI_Console.ConsoleCommands.Rules.User
{
    internal class MarkMaterialLearnedCommand : IConsoleCommand
    {
        private readonly IRuleUser _ruleUser;
        private readonly IUserAuth _userAuth;
        private readonly ICourseService _courseService;
        private readonly UserDTO _userDTO;

        public MarkMaterialLearnedCommand(IRuleUser ruleUser, IUserAuth userAuth, ICourseService courseService, UserDTO userDTO)
        {
            _ruleUser = ruleUser;
            _userAuth = userAuth;
            _courseService = courseService;
            _userDTO = userDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var configService = Program.Root.GetService<IConfigService>();

            var chosenCourseId = int.Parse(parameters[0]);
            var found = await _courseService.GetById(chosenCourseId);

            var viewMaterials = new PaginateCommand<MaterialDTO>(configService, found.Materials);

            await viewMaterials.Run();

            int wantedId = default;
            string input = string.Empty;
            do
            {
                Console.WriteLine("Write id of wanted material or \'return\' to stop: ");

                input = Console.ReadLine();

                if (input.Equals("return"))
                {
                    return true;
                }

                try
                {
                    wantedId = int.Parse(input);
                }
                catch
                {
                    if (!input.Equals(string.Empty))
                    {
                        input = string.Empty;
                        continue;
                    }
                }

                try
                {
                    var res = await _ruleUser.MarkLearned(_userAuth.LoggedId, wantedId);

                    _userDTO.MaterialLearned = res.MaterialLearned;
                    _userDTO.CourseProgress = res.CourseProgress;
                    _userDTO.PerkLevel = res.PerkLevel;

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true);

            Console.WriteLine("Success! You marked that material learned");

            return true;
        }
    }
}
