namespace Portal.Application.MappingProfiles
{
    internal class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<Video, VideoDTO>()
                .IncludeBase<Material, MaterialDTO>();

            CreateMap<VideoDTO, Video>()
                .IncludeBase<MaterialDTO, Material>();
        }
    }
}
