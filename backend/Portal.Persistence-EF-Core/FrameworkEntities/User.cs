namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class User : FrameworkEntity
    {
        public string? Login { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Roles { get; set; }

        public ICollection<UserPerk> UserPerks { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<UserMaterial> UserMaterial { get; set; }
    }
}
