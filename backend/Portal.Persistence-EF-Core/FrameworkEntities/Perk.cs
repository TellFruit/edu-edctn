using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persitence_EF_Core.FrameworkEntities
{
    internal class Perk : FrameworkEntity
    {
        public string Name { get; set; }
        
        public ICollection<UserPerk> UserPerks { get; set; }
        public ICollection<Material> Materials { get; set; }
    }
}
