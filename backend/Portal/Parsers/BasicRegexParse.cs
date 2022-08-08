namespace Portal.UI_Console.Parsers
{
    internal class BasicRegexParse : IParseInput
    {
        private string _regex;

        public BasicRegexParse(string regex)
        {
            _regex = regex;
        }

        public ICollection<string> Parse(string input)
        {
            Regex regex = new Regex(_regex);
            Match match = regex.Match(input);

            if (!match.Success)
            {
                throw new ArgumentException(nameof(Regex));
            }

            string ignoreGroup = "";

            if (match.Groups.Count > 1)
            {
                ignoreGroup = "0";
            }

            return match.Groups.Values.Where(g => g.Name != ignoreGroup).Select(g => g.Value).ToList();
        }
    }
}
