namespace Portal.Application.MappingProfiles
{
    internal class PerkLevelProfile : Profile
    {
        public PerkLevelProfile()
        {
            CreateMap<PerkLevel, PerkLevelDTO>();

            CreateMap<PerkLevelDTO, PerkLevel>();
        }
    }
}
