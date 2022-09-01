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
            bool courseUncompleted = default;
            int result = default;

            int materialsCount = Course.Materials.Count;
            int addPerMaterial = DomainConstants.ProgressFullfiled / materialsCount;
            foreach(var ml in User.MaterialLearned)
            {
                if (CourseContainsMaterial(ml.MaterialId))
                {
                    result += addPerMaterial;
                }
                else
                {
                    courseUncompleted = true;
                }
            }

            if (courseUncompleted
                || User.MaterialLearned.Any() is false)
            {
                Progress = result;
            }
            else
            {
                Progress = DomainConstants.ProgressFullfiled;
            }
        }

        private bool CourseContainsMaterial(int materialId)
        {
            return Course.Materials.Any(m => m.Id.Equals(materialId));
        }
    }
}
