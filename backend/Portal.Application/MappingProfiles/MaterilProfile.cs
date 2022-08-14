namespace Portal.Application.MappingProfiles
{
    public class MaterilProfile : Profile
    {
        public MaterilProfile()
        {
            CreateMap<MaterialDomain, MaterialDTO>();

            CreateMap<MaterialDTO, MaterialDomain>();
        }
    }
}
