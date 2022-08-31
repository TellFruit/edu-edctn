namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class UserEntityProfile : Profile
    {
        public UserEntityProfile(IMapper mapper)
        {
            CreateMap<UserDomain, User>();

            CreateMap<User, UserDomain>()
                .ForMember(dom => dom.CourseProgress,
                    src => src.MapFrom(
                        entity => entity.UserCourses
                            .Select(
                                uc => mapper.Map<CourseProgress>(uc))
                                    .ToList()));
        }
    }
}
