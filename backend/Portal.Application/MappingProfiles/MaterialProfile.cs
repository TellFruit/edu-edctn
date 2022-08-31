namespace Portal.Application.MappingProfiles
{
    internal class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<MaterialDomain, MaterialDTO>();

            CreateMap<MaterialDTO, MaterialDomain>();
        }
    }
}
