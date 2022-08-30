using Portal.Domain.Entities.Abstract;

namespace Portal.Domain.Entities
{
    public class UserDomain : BaseEntity
    {
        #region Model Properties

        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }

        public ICollection<UserPerkDomain> UserPerks { get; set; }
        public ICollection<CourseProgress> CourseProgress { get; set; }
        public ICollection<MaterialLearned> MaterialLearned { get; set; }

        #endregion

        #region Public Business Rules

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

            RecalculateProgress(CourseProgress);

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

            RecalculateProgress(GetProgressByMaterial(materialId));

            return true;
        }

        public bool UnmarkMaterialCompleted(int materialId)
        {
            if (!MaterialLearnedExists(materialId))
            {
                return false;
            }

            MaterialLearned
                .Remove(MaterialLearned
                    .First(x => x.MaterialId
                        .Equals(materialId)));

            RecalculateProgress(GetProgressByMaterial(materialId));

            return true;
        }

        #endregion

        #region Private Support Methods
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

        #endregion
    }
}
