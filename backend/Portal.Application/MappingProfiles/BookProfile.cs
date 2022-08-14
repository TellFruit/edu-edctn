namespace Portal.Application.MappingProfiles
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDomain, BookDTO>()
                .IncludeBase<MaterialDomain, MaterialDTO>();

            CreateMap<BookDTO, BookDomain>()
                .IncludeBase<MaterialDTO, MaterialDomain>();
        }
    }
}
