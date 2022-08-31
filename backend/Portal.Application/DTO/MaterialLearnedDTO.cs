namespace Portal.Application.DTO
{
    public class MaterialLearnedDTO
    {
        public int UserId { get; set; }
        public int MaterialId { get; set; }

        public MaterialDTO Material { get; set; }
    }
}
