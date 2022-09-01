namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class UserEntityProfile : Profile
    {
        public UserEntityProfile()
        {
            CreateMap<UserDomain, User>();

            CreateMap<User, UserDomain>()
                .ForMember(dom => dom.CourseProgress,
                    src => src.MapFrom(uc => uc.UserCourses))
                .ForMember(dom => dom.MaterialLearned,
                    src => src.MapFrom(ml => ml.UserMaterial))
                .ForMember(dom => dom.PerkLevel,
                    src => src.MapFrom(up => up.UserPerks));
        }
    }
}
