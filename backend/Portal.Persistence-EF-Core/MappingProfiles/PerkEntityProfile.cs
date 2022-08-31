namespace Portal.Persistence_EF_Core.MappingProfiles
{
    public class PerkEntityProfile : Profile
    {
        public PerkEntityProfile()
        {
            CreateMap<PerkDomain, Perk>();

            CreateMap<Perk, PerkDomain>();
        }
    }
}
