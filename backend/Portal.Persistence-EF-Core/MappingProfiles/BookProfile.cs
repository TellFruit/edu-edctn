using AutoMapper;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDomain, Book>()
                .IncludeBase<MaterialDomain, Material>();

            CreateMap<Book, BookDomain>()
                .IncludeBase<Material, MaterialDomain>();
        }
    }
}
