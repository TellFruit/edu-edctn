namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class UserMaterialEntityProfile : Profile
    {
        public UserMaterialEntityProfile()
        {
            CreateMap<UserMaterial, MaterialLearned>();

            CreateMap<MaterialLearned, UserMaterial>();
        }
    }
}
