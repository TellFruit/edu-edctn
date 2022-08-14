using AutoMapper;
using Portal.Domain.Entities.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    public class MaterialEntityProfile : Profile
    {
        public MaterialEntityProfile()
        {
            CreateMap<MaterialDomain, Material>();

            CreateMap<Material, MaterialDomain>();
        }
    }
}
