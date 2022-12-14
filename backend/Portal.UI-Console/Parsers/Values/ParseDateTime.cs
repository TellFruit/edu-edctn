using Portal.Application;
using System.Globalization;

namespace Portal.UI_Console.Parsers.Values
{
    internal class ParseDateTime : IParseValue<DateTime>
    {
        private static string[] validFormats = new[] 
        { 
            "MM/dd/yyyy", "MM/dd/yyyy HH:mm:ss",
            "dd.MM.yyyy", "dd.MM.yyyy HH:mm:ss",
            "yyyy"
        };

        public DateTime Parse(string input)
        {
            DateTime dateTime;

            CultureInfo provider = CultureInfo.InvariantCulture;

            DateTime.TryParseExact(input, validFormats, provider, DateTimeStyles.None, out dateTime);

            if (!input.Contains('.') && !input.Contains('/'))
            {
                var mark = ApplicationConstants.YearOnlyDateMark;

                dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                    mark, mark, mark);
            }

            return dateTime;
        }
    }
}
