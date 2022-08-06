namespace Portal.Application.MappingProfiles
{
    internal class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<Video, VideoDTO>();

            CreateMap<VideoDTO, Video>();
        }
    }
}
