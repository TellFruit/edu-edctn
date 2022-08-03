using Portal.Domain.Entities.Abstract;
namespace Portal.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
