using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class Video : Material
    {
        public TimeSpan Duration { get; set; }
        public int Quality { get; set; }
    }
}
