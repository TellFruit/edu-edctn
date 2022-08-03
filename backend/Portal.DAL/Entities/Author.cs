using Portal.DAL.Entities.Abstract;
namespace Portal.DAL.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
