using Portal.Domain.Entities.Abstract;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class BookEntityProfile : Profile
    {
        public BookEntityProfile()
        {
            CreateMap<BookDomain, Book>()
                .IncludeBase<MaterialDomain, Material>();

            CreateMap<Book, BookDomain>()
                .IncludeBase<Material, MaterialDomain>();
        }
    }
}
