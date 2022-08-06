namespace Portal.Application.MappingProfiles
{
    internal class PerkProfile : Profile
    {
        public PerkProfile()
        {
            CreateMap<Perk, PerkDTO>();

            CreateMap<PerkDTO, Perk>();
        }
    }
}
