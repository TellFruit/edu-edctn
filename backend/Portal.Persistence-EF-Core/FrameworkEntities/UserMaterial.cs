namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class UserMaterial
    {
        public int UserId { get; set; }
        public int MaterialId { get; set; }

        public User User { get; set; }
        public Material Material { get; set; }
    }
}
