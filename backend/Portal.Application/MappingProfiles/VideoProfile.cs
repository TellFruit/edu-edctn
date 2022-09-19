using Portal.Domain.Entities.Material;

namespace Portal.Application.MappingProfiles
{
    internal class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<VideoDomain, VideoDTO>()
                .IncludeBase<MaterialDomain, MaterialDTO>();

            CreateMap<VideoDTO, VideoDomain>()
                .IncludeBase<MaterialDTO, MaterialDomain>();
        }
    }
}
