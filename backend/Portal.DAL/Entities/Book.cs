using Portal.DAL.Entities.Abstract;

namespace Portal.DAL.Entities
{
    public class Book : Material
    {
        public int PageCount { get; set; }
        public string Format { get; set; }
        public DateTime Published { get; set; }
    }
}
