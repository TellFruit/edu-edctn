using Portal.Domain.Entities.Course;

namespace Portal.Domain.Entities.User
{
    public class UserDomain : BaseEntity
    {
        #region Model Properties

        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public ICollection<PerkLevel> PerkLevel { get; set; }
        public ICollection<CourseProgress> CourseProgress { get; set; }
        public ICollection<MaterialLearned> MaterialLearned { get; set; }

        public UserDomain()
        {
            PerkLevel = new List<PerkLevel>();
            CourseProgress = new List<CourseProgress>();
            MaterialLearned = new List<MaterialLearned>();
        }

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
            if (CourseProgressExists(courseId) is false)
            {
                return false;
            }

            var found = CourseProgress
                .First(x => x.CourseId
                    .Equals(courseId));

            if (found.CourseFinished)
            {
                throw new InvalidOperationException("Cannot unenroll from the finished course");
            }

            CourseProgress.Remove(found);

            return true;
        }

        public bool MarkMaterialLearned(int materialId)
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

        public bool UnmarkMaterialLearned(int materialId)
        {
            if (MaterialLearnedExists(materialId) is false)
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

        public void GainPerksFromCourse(CourseDomain course)
        {
            foreach (var perk in course.Perks)
            {
                var found = PerkLevel
                    .FirstOrDefault(
                        x => x.Perk.Id.Equals(perk.Id));

                if (found == null)
                {
                    PerkLevel.Add(new PerkLevel
                    {
                        UserId = Id,
                        PerkId = perk.Id,
                        Level = 1,
                        Perk = perk
                    });
                }
                else
                {
                    found.User = this;
                    found.Reestimate();
                }
            }
        }

        #endregion

        #region Private Support Methods
        private bool CourseProgressExists(int courseId)
        {
            return CourseProgress
                .Any(c => c.CourseId.Equals(courseId));
        }

        private bool MaterialLearnedExists(int materialId)
        {
            return MaterialLearned
                .Any(m => m.MaterialId.Equals(materialId));
        }

        private void RecalculateProgress(ICollection<CourseProgress> progresses)
        {
            foreach (var progress in progresses)
            {
                progress.User = this;
                progress.CallChanges();
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
