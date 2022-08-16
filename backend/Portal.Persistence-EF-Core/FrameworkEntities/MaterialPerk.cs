namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class MaterialPerk
    {
        public int PerkId { get; set; }
        public int MaterialId { get; set; }

        public Perk Perk { get; set; }
        public Material Material { get; set; }
    }
}
