using System.Globalization;

namespace Portal.Application.DTO
{
    public class BookDTO : MaterialDTO
    {
        public int PageCount { get; set; }
        public string Format { get; set; }
        public DateTime Published { get; set; }
        public ICollection<string> Authors { get; set; }
        public ICollection<Perk> Perks { get; set; }

        public override string ToString()
        {
            // template: Е. Таненбаум - Сучасні операційні системи, 1365 (2013).pdf

            string date;

            if (Published.Hour == 1 && Published.Minute == 1 && Published.Second == 1)
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

            return $"{string.Join(", ", Authors)} - {Title}, {PageCount} ({date}){Format}";
        }
    }
}
