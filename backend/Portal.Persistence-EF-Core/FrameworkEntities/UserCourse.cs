namespace Portal.Persistence_EF_Core.FrameworkEntities
{
    internal class UserCourse
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Progress { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}
