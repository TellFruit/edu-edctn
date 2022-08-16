using Portal.Persistence_EF_Core.FrameworkEntities;

namespace Portal.Persitence_EF_Core.FrameworkEntities
{
    internal class Perk : FrameworkEntity
    {
        public string Name { get; set; }
        
        public ICollection<User> Users { get; set; }
        public ICollection<Material> Materials { get; set; }

        public ICollection<UserPerk> UserPerks { get; set; }
        public ICollection<MaterialPerk> MaterialPerks { get; set; }
    }
}
