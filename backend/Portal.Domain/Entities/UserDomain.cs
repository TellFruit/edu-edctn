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

            RecalculateWhereMaterial(materialId);

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

        private void RecalculateWhereMaterial(int materialId)
        {
            RecalculateProgress(GetProgressByMaterial(materialId));
        }

        private void RecalculateAllProgress()
        {
            RecalculateProgress(CourseProgress);
        }

        private void RecalculateProgress(ICollection<CourseProgress> progresses)
        {
            foreach (var progress in progresses)
            {
                progress.User = this;
                progress.Recalculate();
            }
        }

        private ICollection<CourseProgress> GetProgressByMaterial(int materialId)
        {
            return CourseProgress
                .Where(c => c.Course.Materials
                    .Select(m => m.Id)
                        .Contains(materialId))
                .ToList();
        }
    }
}
