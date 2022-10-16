namespace Portal.Persistence_EF_Core.Repositories.Extension
{
    internal static class PerkExtension
    {
        public static void MapFromPerkDomain(this Perk perk, PerkDomain data)
        {
            perk.Name = data.Name;
            perk.UpdatedAt = data.UpdatedAt;
        }
    }
}
