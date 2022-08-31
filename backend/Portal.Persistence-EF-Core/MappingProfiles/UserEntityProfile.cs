namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class UserEntityProfile : Profile
    {
        public UserEntityProfile()
        {
            CreateMap<UserDomain, User>();

            CreateMap<User, UserDomain>()
                .ForMember(dom => dom.CourseProgress,
                   src => src.MapFrom(uc => uc.UserCourses));
                //.ForMember(dom => dom.CourseProgress,
                //    src => src.MapFrom(
                //        entity => entity.UserCourses
                //            .Select(
                //                uc => mapper.Map<CourseProgress>(uc))
                //                    .ToList()));
        }
    }
}
