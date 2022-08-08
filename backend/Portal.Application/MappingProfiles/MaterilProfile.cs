namespace Portal.Application.MappingProfiles
{
    public class MaterilProfile : Profile
    {
        public MaterilProfile()
        {
            CreateMap<Material, MaterialDTO>();

            CreateMap<MaterialDTO, Material>();
        }
    }
}
