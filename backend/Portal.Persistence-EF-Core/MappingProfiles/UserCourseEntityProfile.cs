namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class UserCourseEntityProfile : Profile
    {
        public UserCourseEntityProfile()
        {
            CreateMap<CourseProgress, UserCourse>();

            CreateMap<UserCourse, CourseProgress>();
        }
    }
}
