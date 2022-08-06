namespace Portal.Application.MappingProfiles
{
    internal class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDTO>();

            CreateMap<CourseDTO, Course>();
        }
    }
}
