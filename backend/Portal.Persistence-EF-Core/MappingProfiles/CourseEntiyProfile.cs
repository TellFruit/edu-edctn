namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class CourseEntiyProfile : Profile
    {
        public CourseEntiyProfile()
        {
            CreateMap<CourseDomain, Course>();

            CreateMap<Course, CourseDomain>()
                .ForMember(dom => dom.Materials, 
                    src => src.MapFrom(
                        ef =>
                            ef.CourseMaterials
                                .Select(cm => cm.Material)
                                .ToList()));
        }
    }
}
