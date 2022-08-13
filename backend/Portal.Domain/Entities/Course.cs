using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public User Author { get; set; }

        public ICollection<Material> Materials { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
