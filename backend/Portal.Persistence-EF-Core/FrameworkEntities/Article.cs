namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class Article : Material
    {
        public string Url { get; set; }
        public DateTime Published { get; set; }
    }
}
