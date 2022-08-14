using AutoMapper;
using Portal.Domain.Entities;
using Portal.Persitence_EF_Core.FrameworkEntities;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class CourseEntiyProfile : Profile
    {
        public CourseEntiyProfile()
        {
            CreateMap<CourseDomain, Course>();

            CreateMap<Course, CourseDomain>();
        }
    }
}
