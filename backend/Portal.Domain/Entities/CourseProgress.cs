namespace Portal.Domain.Entities
{
    public class CourseProgress
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Progress { get; set; }
        public bool CourseFinished => Progress >= DomainConstants.ProgressFullfiled;

        public UserDomain User { get; set; }
        public CourseDomain Course { get; set; }

        public void CallChanges()
        {
            if (CourseFinished)
            {
                return;
            }

            Recalculate();

            if (CourseFinished)
            {
                User.GainPerksFromCourse(Course);
            }
        }

        private void Recalculate()
        {
            int result = default;

            int materialsCount = Course.Materials.Count;
            int addPerMaterial = DomainConstants.ProgressFullfiled / materialsCount;

            var filtered = MaterialLearnedByCourse();
            foreach (var ml in filtered)
            {
                result += addPerMaterial;
            }

            if (filtered.Count < Course.Materials.Count)
            {
                Progress = result;
            }
            else
            {
                Progress = DomainConstants.ProgressFullfiled;
            }
        }

        private ICollection<MaterialLearned> MaterialLearnedByCourse()
        {
            return User.MaterialLearned
                .Where(ml => Course.Materials
                    .Select(m => m.Id)
                    .Contains(ml.MaterialId))
                .ToList();
        }
    }
}
