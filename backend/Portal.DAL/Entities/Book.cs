using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class Book : Material
    {
        public int PageCount { get; set; }
        public string Format { get; set; }
        public DateTime Published { get; set; }
        public ICollection<string> Authors { get; set; }
    }
}
