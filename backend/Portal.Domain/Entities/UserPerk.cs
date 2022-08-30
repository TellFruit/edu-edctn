namespace Portal.Domain.Entities
{
    public class UserPerk
    {
        public int UserId { get; set; }
        public int PerkId { get; set; }
        public int Level { get; set; }

        public UserDomain User { get; set; }
        public PerkDomain Perk { get; set; }

        public void Reestimate()
        {

        }
    }
}
