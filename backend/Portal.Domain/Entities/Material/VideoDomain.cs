namespace Portal.Domain.Entities.Material
{
    public class VideoDomain : MaterialDomain
    {
        public TimeSpan Duration { get; set; }
        public int Quality { get; set; }
    }
}
