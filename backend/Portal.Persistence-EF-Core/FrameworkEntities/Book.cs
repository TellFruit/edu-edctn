using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persitence_EF_Core.FrameworkEntities
{
    internal class Book : Material
    {
        public int PageCount { get; set; }
        public string Format { get; set; }
        public DateTime Published { get; set; }
        public string Authors { get; set; }
    }
}
