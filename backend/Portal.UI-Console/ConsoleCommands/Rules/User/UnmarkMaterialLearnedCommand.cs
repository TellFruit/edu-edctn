namespace Portal.UI_Console.ConsoleCommands.Rules.User
{
    internal class UnmarkMaterialLearnedCommand : IConsoleCommand
    {
        private readonly IRuleUser _ruleUser;
        private readonly CourseDTO _courseDTO;
        private readonly UserDTO _userDTO;

        public UnmarkMaterialLearnedCommand(IRuleUser ruleUser, UserDTO userDTO, CourseDTO courseDTO)
        {
            _ruleUser = ruleUser;
            _userDTO = userDTO;
            _courseDTO = courseDTO;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var materialId = int.Parse(parameters[0]);

            var contained = _courseDTO.Materials
                .Select(m => m.Id)
                .Contains(materialId);

            if (contained is false)
            {
                Console.WriteLine("Sorry, this material is not present in the course!");
                return false;
            }

            try
            {
                var res = await _ruleUser.UnmarkLearned(_userDTO.Id, materialId);

                _userDTO.MaterialLearned = res.MaterialLearned;
                _userDTO.CourseProgress = res.CourseProgress;
                _userDTO.PerkLevel = res.PerkLevel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Success! You marked that material NOT learned.");

            return false;
        }
    }
}
