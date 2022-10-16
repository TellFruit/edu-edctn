namespace Portal.UI_MVC_Web.MappingProfiles
{
    public class CourseVideoModelProfile : Profile
    {
        public CourseVideoModelProfile()
        {
            CreateMap<CourseVideoModel, VideoDTO>();

            CreateMap<VideoDTO, CourseVideoModel>();
        }
    }
}
