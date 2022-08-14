using Portal.Persitence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class UserCourse : FrameworkEntity
    {
        public int Id { get; set; }
        public int Progress { get; set; }

        public Course Course { get; set; }
        public User User { get; set; }
    }
}
