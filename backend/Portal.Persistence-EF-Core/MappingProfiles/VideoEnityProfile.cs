using Portal.Domain.Entities.Abstract;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class VideoEnityProfile : Profile
    {
        public VideoEnityProfile()
        {
            CreateMap<VideoDomain, Video>()
                .IncludeBase<MaterialDomain, Material>();

            CreateMap<Video, VideoDomain>()
                .IncludeBase<Material, MaterialDomain>();
        }
    }
}
