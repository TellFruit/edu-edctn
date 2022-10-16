namespace Portal.Application.MappingProfiles
{
    internal class MaterialLearnedProfile : Profile
    {
        public MaterialLearnedProfile()
        {
            CreateMap<MaterialLearned, MaterialLearnedDTO>();

            CreateMap<MaterialLearnedDTO, MaterialLearned>();
        }
    }
}
