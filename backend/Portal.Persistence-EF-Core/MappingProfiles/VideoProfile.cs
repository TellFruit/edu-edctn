using AutoMapper;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<VideoDomain, Video>()
                .IncludeBase<MaterialDomain, Material>();

            CreateMap<Video, VideoDomain>()
                .IncludeBase<Material, MaterialDomain>();
        }
    }
}
