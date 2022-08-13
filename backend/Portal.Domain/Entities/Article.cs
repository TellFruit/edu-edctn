using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class Article : Material
    {
        public string Url { get; set; }
        public DateTime Published { get; set; }
    }
}
