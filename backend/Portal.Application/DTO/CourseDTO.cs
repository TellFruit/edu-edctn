namespace Portal.Application.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public UserDTO Author { get; set; }

        public ICollection<MaterialDTO> Materials { get; set; }

        public CourseDTO()
        {
            Materials = new List<MaterialDTO>();
        }

        public override string ToString()
        {
            return $"{Id} - {Name}: {Description}";
        }
    }
}
