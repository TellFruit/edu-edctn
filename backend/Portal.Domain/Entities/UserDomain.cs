using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class UserDomain : BaseEntity
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }

        public ICollection<UserPerkDomain> UserPerks { get; set; }
        public ICollection<CourseProgress> CourseProgress { get; set; }
        public ICollection<MaterialDomain> Materials { get; set; }

        public bool CourseEnroll(int courseId)
        {
            if (CourseProgressExists(courseId))
            {
                return false;
            }

            CourseProgress.Add(new CourseProgress
            {
                UserId = Id,
                CourseId = courseId,
                Progress = 0
            });

            return true;
        }

        public bool CourseUnenroll(int courseId)
        {
            if (!CourseProgressExists(courseId))
            {
                return false;
            }

            CourseProgress
                .Remove(CourseProgress
                    .First(x => x.CourseId
                        .Equals(courseId)));

            return true;
        }

        private bool CourseProgressExists(int courseId)
        {
            return CourseProgress
                .Where(c => c.Equals(courseId))
                .Any();
        }
    }
}
