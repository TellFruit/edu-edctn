namespace Portal.Persistence_EF_Core.FrameworkEntities.Abstract
{
    internal abstract class FrameworkEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
