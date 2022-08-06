namespace Portal.Application.DTO
{
    public class BookDTO : MaterialDTO
    {
        public int PageCount { get; set; }
        public string Format { get; set; }
        public DateTime Published { get; set; }
        public ICollection<string> Authors { get; set; }
        public ICollection<Perk> Perks { get; set; }
    }
}
