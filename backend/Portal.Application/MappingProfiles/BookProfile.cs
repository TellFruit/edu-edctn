namespace Portal.Application.MappingProfiles
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDomain, BookDTO>()
                .ForMember(dto => dto.Authors,
                    src =>
                        src.MapFrom(dom => dom.Authors
                            .Split(", ", StringSplitOptions.None)
                                .ToList()))
                .IncludeBase<MaterialDomain, MaterialDTO>();

            CreateMap<BookDTO, BookDomain>()
                .ForMember(dom => dom.Authors,
                    src =>
                        src.MapFrom(
                            dto =>
                                string.Join(", ", dto.Authors)))
                .IncludeBase<MaterialDTO, MaterialDomain>();
        }
    }
}
