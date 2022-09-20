using System.Globalization;

namespace Portal.Application.DTO
{
    public class BookDTO : MaterialDTO
    {
        public int PageCount { get; set; }
        public string Format { get; set; }
        public DateTime Published { get; set; }
        public IList<string> Authors { get; set; }

        public override string ToString()
        {
            // template: Е. Таненбаум - Сучасні операційні системи, 1365 (2013).pdf

            string date;

            var mark = ApplicationConstants.YearOnlyDateMark;

            if (Published.Hour == mark && Published.Minute == mark && Published.Second == mark)
            {
                date = Published.ToString("yyyy");
            }
            else if (CultureInfo.CurrentCulture.Name.ToLower().Contains("ua") ||
                CultureInfo.CurrentCulture.Name.ToLower().Contains("ru"))
            {
                date = Published.ToString("dd.MM.yyyy");
            }
            else
            {
                date = Published.ToString("MM/dd/yyyy");
            }

            return $"{Id} - {string.Join(", ", Authors)} - {Title}, {PageCount} ({date}){Format}";
        }
    }
}
