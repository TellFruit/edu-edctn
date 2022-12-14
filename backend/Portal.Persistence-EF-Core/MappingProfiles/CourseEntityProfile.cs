namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class CourseEntityProfile : Profile
    {
        public CourseEntityProfile()
        {
            CreateMap<CourseDomain, Course>();

            CreateMap<Course, CourseDomain>()
                .ForMember(dom => dom.Materials,
                    src => src.MapFrom(
                        ef =>
                            ef.CourseMaterials
                                .Select(cm => cm.Material)
                                .ToList()))
                .ForMember(dom => dom.Perks,
                    src => src.MapFrom(
                        ef =>
                            ef.CoursePerks
                                .Select(cp => cp.Perk)
                                .ToList()));
        }
    }
}
