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
        public ICollection<MaterialLearned> MaterialLearned { get; set; }

        public bool CourseEnroll(CourseDomain course)
        {
            if (CourseProgressExists(course.Id))
            {
                return false;
            }

            CourseProgress.Add(new CourseProgress
            {
                UserId = Id,
                CourseId = course.Id,
                Progress = 0,
                Course = course
            });

            RecalculateAllProgress();

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

        public bool MarkMaterialCompleted(int materialId)
        {
            if (MaterialLearnedExists(materialId))
            {
                return false;
            }

            MaterialLearned.Add(new MaterialLearned
            {
                UserId = Id,
                MaterialId = materialId,
            });

            RecalculateAllProgress();

            return true;
        }

        private bool CourseProgressExists(int courseId)
        {
            return CourseProgress
                .Where(c => c.Equals(courseId))
                .Any();
        }

        private bool MaterialLearnedExists(int materialId)
        {
            return MaterialLearned
                .Where(c => c.Equals(materialId))
                .Any();
        }

        private void RecalculateAllProgress()
        {
            foreach(var progress in CourseProgress)
            {
                progress.User = this;
                progress.Recalculate();
            }
        }
    }
}
