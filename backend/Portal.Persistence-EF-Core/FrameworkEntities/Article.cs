using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persitence_EF_Core.FrameworkEntities
{
    public class Article : Material
    {
        public string Url { get; set; }
        public DateTime Published { get; set; }
    }
}
