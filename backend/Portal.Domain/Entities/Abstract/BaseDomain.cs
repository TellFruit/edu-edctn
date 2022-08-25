namespace Portal.Domain.Entities.Abstract
{
    public abstract class BaseDomain
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
