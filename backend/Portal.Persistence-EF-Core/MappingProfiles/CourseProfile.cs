using AutoMapper;
using Portal.Domain.Entities;
using Portal.Persitence_EF_Core.FrameworkEntities;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseDomain, Course>();

            CreateMap<Course, CourseDomain>();
        }
    }
}
