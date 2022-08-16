using Portal.Persistence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Persitence_EF_Core.FrameworkEntities
{
    internal class Course : FrameworkEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }

        public User? User { get; set; }

        public ICollection<Material> Materials { get; set; }
        public ICollection<User> Users { get; set; }

        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<CourseMaterial> CourseMaterials { get; set; }
    }
}
