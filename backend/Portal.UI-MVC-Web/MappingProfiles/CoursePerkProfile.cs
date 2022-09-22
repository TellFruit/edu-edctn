namespace Portal.UI_MVC_Web.MappingProfiles
{
    public class CoursePerkProfile : Profile
    {
        public CoursePerkProfile()
        {
            CreateMap<CoursePerkModel, PerkDTO>();

            CreateMap<PerkDTO, CoursePerkModel>();
        }
    }
}
