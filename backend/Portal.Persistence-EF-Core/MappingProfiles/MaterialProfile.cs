using AutoMapper;
using Portal.Domain.Entities.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<MaterialDomain, Material>();

            CreateMap<Material, MaterialDomain>();
        }
    }
}
