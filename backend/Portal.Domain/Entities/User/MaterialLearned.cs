using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities.User
{
    public class MaterialLearned
    {
        public int UserId { get; set; }
        public int MaterialId { get; set; }

        public MaterialDomain Material { get; set; }
    }
}
