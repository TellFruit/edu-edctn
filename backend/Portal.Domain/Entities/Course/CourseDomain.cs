using Portal.Domain.Entities.Perk;
using Portal.Domain.Entities.User;

namespace Portal.Domain.Entities.Course
{
    public class CourseDomain : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public UserDomain Author { get; set; }

        public ICollection<MaterialDomain> Materials { get; set; }
        public ICollection<PerkDomain> Perks { get; set; }
        public ICollection<UserDomain> Users { get; set; }
    }
}
