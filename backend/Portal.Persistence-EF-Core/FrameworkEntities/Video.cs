namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class Video : Material
    {
        public TimeSpan Duration { get; set; }
        public int Quality { get; set; }
    }
}
