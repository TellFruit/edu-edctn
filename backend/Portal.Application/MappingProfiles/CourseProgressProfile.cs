namespace Portal.Application.MappingProfiles
{
    internal class CourseProgressProfile : Profile
    {
        public CourseProgressProfile()
        {
            CreateMap<CourseProgress, CourseProgressDTO>();

            CreateMap<CourseProgressDTO, CourseProgress>();
        }
    }
}
