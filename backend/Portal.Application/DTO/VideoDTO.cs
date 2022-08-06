namespace Portal.Application.DTO
{
    public class VideoDTO : MaterialDTO
    {
        public TimeSpan Duration { get; set; }
        public int Quality { get; set; }
        public ICollection<Perk> Perks { get; set; }
    }
}
