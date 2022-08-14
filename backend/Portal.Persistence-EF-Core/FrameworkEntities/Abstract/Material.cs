namespace Portal.Persitence_EF_Core.FrameworkEntities.Abstract
{
    internal class Material : FrameworkEntity
    {
        public string Title { get; set; }

        public ICollection<Perk> Perks { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
