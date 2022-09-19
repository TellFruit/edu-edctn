using Portal.Domain.Entities.Abstract;
using Portal.Domain.Entities.User;

namespace Portal.Domain.Entities.Perk
{
    public class PerkDomain : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<PerkLevel> UserPerks { get; set; }
        public ICollection<MaterialDomain> Materials { get; set; }
    }
}
