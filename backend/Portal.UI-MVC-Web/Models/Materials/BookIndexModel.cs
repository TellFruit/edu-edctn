namespace Portal.UI_MVC_Web.Models.Materials
{
    public class BookIndexModel
    {
        public ICollection<BookDTO> Books { get; set; }

        public BookIndexModel(ICollection<BookDTO> books)
        {
            Books = books;
        }
    }
}
