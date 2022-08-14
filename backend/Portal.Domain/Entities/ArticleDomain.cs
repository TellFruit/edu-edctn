using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class ArticleDomain : MaterialDomain
    {
        public string Url { get; set; }
        public DateTime Published { get; set; }
    }
}
