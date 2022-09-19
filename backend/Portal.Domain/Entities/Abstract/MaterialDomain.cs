using Portal.Domain.Entities.Course;
using Portal.Domain.Entities.User;

namespace Portal.Domain.Entities.Abstract
{
    public abstract class MaterialDomain : BaseEntity
    {
        public string Title { get; set; }

        public ICollection<UserDomain> Users { get; set; }
        public ICollection<CourseDomain> Courses { get; set; }
    }
}
