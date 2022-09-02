namespace Portal.Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }

        public ICollection<CourseProgressDTO> CourseProgress { get; set; }
        public ICollection<MaterialLearnedDTO> MaterialLearned { get; set; }
        public ICollection<PerkLevelDTO> PerkLevel { get; set; }

        public UserDTO()
        {
            CourseProgress = new List<CourseProgressDTO>();
            MaterialLearned = new List<MaterialLearnedDTO>();
            PerkLevel = new List<PerkLevelDTO>();
        }
    }
}
