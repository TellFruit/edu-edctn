using Portal.Persistence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persitence_EF_Core.FrameworkEntities
{
    internal class User : FrameworkEntity
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<string> Roles { get; set; }

        public ICollection<UserPerk> UserPerks { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
