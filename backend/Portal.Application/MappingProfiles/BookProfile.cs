namespace Portal.Application.MappingProfiles
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>();

            CreateMap<BookDTO, Book>();
        }
    }
}
