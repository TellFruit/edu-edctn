using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class VideoDomain : MaterialDomain
    {
        public TimeSpan Duration { get; set; }
        public int Quality { get; set; }
    }
}
