namespace Portal.Domain.Entities
{
    public class PerkLevel
    {
        public int UserId { get; set; }
        public int PerkId { get; set; }
        public int Level { get; set; }

        public UserDomain User { get; set; }
        public PerkDomain Perk { get; set; }

        public void Reestimate()
        {
            int res = default;

            var found = GetCompletedProgressesByPerk(PerkId);

            foreach(var completed in found)
            {
                res++;
            }

            if (res > 0)
            {
                Level = res;
            }
        }

        private ICollection<CourseProgress> GetCompletedProgressesByPerk(int perkId)
        {
            return User.CourseProgress
                .Where(c => c.CourseFinished
                    && c.Course.Perks.Any(p => p.Id.Equals(perkId))).ToList();
        }
    }
}
