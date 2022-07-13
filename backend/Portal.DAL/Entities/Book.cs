using Portal.DAL.Entities.Abstract;
using System.Collections;

namespace Portal.DAL.Entities
{
    public class Book : Material
    {
        public Book()
        {
            Authors = new List<Author>();
        }

        public int PageCount { get; set; }
        public string Format { get; set; }
        public DateTime Published { get; set; }
        public ICollection Authors { get; private set; }
    }
}
