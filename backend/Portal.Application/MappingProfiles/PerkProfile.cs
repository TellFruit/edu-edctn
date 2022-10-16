namespace Portal.Application.MappingProfiles
{
    internal class PerkProfile : Profile
    {
        public PerkProfile()
        {
            CreateMap<PerkDomain, PerkDTO>();

            CreateMap<PerkDTO, PerkDomain>();
        }
    }
}
