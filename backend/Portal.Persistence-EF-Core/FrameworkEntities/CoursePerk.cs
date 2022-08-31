namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class CoursePerk
    {
        public int CourseId { get; set; }
        public int PerkId { get; set; }

        public Course Course { get; set; }
        public Perk Perk { get; set; }
    }
}
