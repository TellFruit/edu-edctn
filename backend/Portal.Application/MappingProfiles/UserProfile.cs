namespace Portal.Application.MappingProfiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDomain, UserDTO>();

            CreateMap<UserDTO, UserDomain>();
        }
    }
}
