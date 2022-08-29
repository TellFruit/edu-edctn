using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class CourseProgress
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Progress { get; set; }
        public bool CourseFinished => Progress >= DomainConstants.ProgressFullfiled;

        public CourseDomain Course { get; set; }
    }
}
