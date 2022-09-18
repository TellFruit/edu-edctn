using Portal.Domain.Entities.Course;

namespace Portal.Application.MappingProfiles
{
    internal class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseDomain, CourseDTO>();

            CreateMap<CourseDTO, CourseDomain>();
        }
    }
}
