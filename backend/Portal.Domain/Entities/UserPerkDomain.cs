namespace Portal.Domain.Entities
{
    public class UserPerkDomain
    {
        public int Id { get; set; }
        public int Level { get; set; }

        public PerkDomain Perk { get; set; }
        public UserDomain User { get; set; }
    }
}
