namespace Portal.UI_Console.Parsers
{
    internal class BasicSplitParse : IParseInput
    {
        private string _match;

        public BasicSplitParse(string match)
        {
            _match = match;
        }

        public ICollection<string> Parse(string input)
        {
            return input.Split(_match);
        }
    }
}
