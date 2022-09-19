namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class UserCourseEntityProfile : Profile
    {
        public UserCourseEntityProfile()
        {
            CreateMap<UserCourse, CourseProgress>();

            CreateMap<CourseProgress, UserCourse>();
        }
    }
}
