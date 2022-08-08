namespace Portal.Application.MappingProfiles
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>()
                .IncludeBase<Material, MaterialDTO>();

            CreateMap<BookDTO, Book>()
                .IncludeBase<MaterialDTO, Material>();
        }
    }
}
