using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class Perk : BaseEntity
    {
        public string Name { get; set; }
        
        public ICollection<UserPerk> UserPerks { get; set; }
        public ICollection<Material> Materials { get; set; }

    }
}
