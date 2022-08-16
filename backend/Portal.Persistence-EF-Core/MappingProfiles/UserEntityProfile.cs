namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class UserEntityProfile : Profile
    {
        public UserEntityProfile()
        {
            CreateMap<UserDomain, User>();

            CreateMap<User, UserDomain>();
        }
    }
}
