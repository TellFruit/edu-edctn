namespace Portal.Application.MappingProfiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<MaterialDomain, MaterialDTO>();

            CreateMap<MaterialDTO, MaterialDomain>();
        }
    }
}
