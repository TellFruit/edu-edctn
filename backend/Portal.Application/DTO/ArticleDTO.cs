using System.Globalization;

namespace Portal.Application.DTO
{
    public class ArticleDTO : MaterialDTO
    {
        public string Url { get; set; }
        public DateTime Published { get; set; }
        public ICollection<PerkDTO> Perks { get; set; }
        public override string ToString()
        {
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

            return $"{Id} - {Title} - {Url}, {date}";
        }
    }
}
