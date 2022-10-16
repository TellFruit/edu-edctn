namespace Portal.Application.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public UserDTO Author { get; set; }

        public ICollection<MaterialDTO> Materials { get; set; }
        public ICollection<PerkDTO> Perks { get; set; }

        public CourseDTO()
        {
            Materials = new List<MaterialDTO>();
            Perks = new List<PerkDTO>();
        }

        public override string ToString()
        {
            return $"{Id} - {Name}: {Description}";
        }
    }
}
