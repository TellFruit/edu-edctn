namespace Portal.UI_Console.ConsoleCommands.Modify.Skills
{
    internal class CreateSkillCommand : IConsoleCommand
    {
        private readonly IPerkService _perkService;

        public CreateSkillCommand(IPerkService perkService)
        {
            _perkService = perkService;
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
             * Tilte
             */

            var toCreate = new PerkDTO()
            {
                Name = parameters[0],
            };

            await _perkService.Create(toCreate);
            Console.WriteLine("Success! Perk created");

            return true;
        }
    }
}
