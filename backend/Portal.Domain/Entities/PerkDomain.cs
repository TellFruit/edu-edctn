using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class PerkDomain : BaseEntity
    {
        public string Name { get; set; }
        
        public ICollection<UserPerkDomain> UserPerks { get; set; }
        public ICollection<MaterialDomain> Materials { get; set; }
    }
}
