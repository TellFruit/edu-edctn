using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.MappingProfiles
{
    internal class CourseProgressProfile : Profile
    {
        public CourseProgressProfile()
        {
            CreateMap<CourseProgress, CourseProgressDTO>();

            CreateMap<CourseProgressDTO, CourseProgress>();
        }
    }
}
