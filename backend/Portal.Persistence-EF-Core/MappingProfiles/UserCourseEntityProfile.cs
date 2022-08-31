using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.MappingProfiles
{
    internal class UserCourseEntityProfile : Profile
    {
        public UserCourseEntityProfile()
        {
            CreateMap<UserCourse, CourseProgress>();

            CreateMap<CourseProgress, UserCourse>();
        }
    }
}
