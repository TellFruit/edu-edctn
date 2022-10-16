namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class UserPerkEntityProfile : Profile
    {
        public UserPerkEntityProfile()
        {
            CreateMap<UserPerk, PerkLevel>();

            CreateMap<PerkLevel, UserPerk>();
        }
    }
}
