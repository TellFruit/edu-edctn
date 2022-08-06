namespace Portal.Application.DTO
{
    public class ArticleDTO : MaterialDTO
    {
        public string Url { get; set; }
        public DateTime Published { get; set; }
        public ICollection<PerkDTO> Perks { get; set; }
    }
}
