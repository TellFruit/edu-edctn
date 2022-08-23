namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class Perk : FrameworkEntity
    {
        public string Name { get; set; }

        public ICollection<UserPerk> UserPerks { get; set; }
        public ICollection<CoursePerk> CoursePerks { get; set; }
    }
}
