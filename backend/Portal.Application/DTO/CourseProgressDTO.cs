using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.DTO
{
    public class CourseProgressDTO
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Progress { get; set; }
        public bool CourseFinished { get; set; }

        public override string ToString()
        {
            return $"Course ID: {CourseId}, Progress made: {Progress}%";
        }
    }
}
