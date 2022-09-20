namespace Portal.UI_MVC_Web.Models.Materials
{
    public class PerkIndexModel
    {
        public ICollection<PerkDTO> Perks { get; set; }

        public PerkIndexModel(ICollection<PerkDTO> perks)
        {
            Perks = perks;
        }
    }
}
