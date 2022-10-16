namespace Portal.Persistence_EF_Core.MappingProfiles
{
    public class MaterialEntityProfile : Profile
    {
        public MaterialEntityProfile()
        {
            CreateMap<MaterialDomain, Material>();

            CreateMap<Material, MaterialDomain>();
        }
    }
}
