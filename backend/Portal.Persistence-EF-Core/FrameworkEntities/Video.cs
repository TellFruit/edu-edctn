using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;

namespace Portal.Persitence_EF_Core.FrameworkEntities
{
    internal class Video : Material
    {
        public TimeSpan Duration { get; set; }
        public int Quality { get; set; }
    }
}
