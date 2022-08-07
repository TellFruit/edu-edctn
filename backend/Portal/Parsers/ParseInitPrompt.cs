using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.Parsers
{
    internal class ParseInitPrompt : IParseInput
    {
        public ICollection<string> Parse(string input)
        {
            ICollection<string> result = new List<string>();

            if (!input.Contains(" "))
            {
                return result.Append(input).ToList();
            }

            int commandStart = input.IndexOf(c => !char.IsWhiteSpace(c));
            int commandEnd = input.IndexOf(commandStart, c => char.IsWhiteSpace(c));

            return result.Append(input.Substring(commandStart, commandEnd - commandStart))
                .Append(input.Substring(commandEnd + 1))
                .ToList();
        }
    }
}
