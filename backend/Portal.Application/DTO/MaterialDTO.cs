namespace Portal.Application.DTO
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title};";
        }
    }
}
