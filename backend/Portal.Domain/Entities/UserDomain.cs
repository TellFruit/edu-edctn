using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class UserDomain : BaseEntity
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }

        public ICollection<UserPerkDomain> UserPerks { get; set; }
        public ICollection<CourseProgress> CourseProgress { get; set; }
        public ICollection<MaterialDomain> Materials { get; set; }
    }
}
