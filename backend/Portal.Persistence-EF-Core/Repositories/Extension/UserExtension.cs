using Portal.Domain.Entities.User;

namespace Portal.Persistence_EF_Core.Repositories.Extension
{
    internal static class UserExtension
    {
        public static ICollection<UserCourse> ToUserCourse(this ICollection<CourseProgress> progress)
        {
            return progress
                .Select(c => new UserCourse
                {
                    UserId = c.UserId,
                    CourseId = c.CourseId,
                    Progress = c.Progress
                })
                .ToList();
        }

        public static ICollection<UserMaterial> ToUserMaterial(this ICollection<MaterialLearned> leaened)
        {
            return leaened
                .Select(m => new UserMaterial
                {
                    UserId = m.UserId,
                    MaterialId = m.MaterialId,
                })
                .ToList();
        }

        public static ICollection<UserPerk> ToUserPerk(this ICollection<PerkLevel> level)
        {
            return level
                .Select(p => new UserPerk
                {
                    UserId = p.UserId,
                    PerkId = p.PerkId,
                    Level = p.Level
                })
                .ToList();
        }

        public static void MapFromUserDomain(this User user,
            UserDomain data,
            ICollection<UserCourse> courses,
            ICollection<UserMaterial> materials,
            ICollection<UserPerk> perks)
        {
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.Email = data.Email;
            user.Password = data.Password;
            user.Roles = data.Roles;
            user.UpdatedAt = data.UpdatedAt;
            user.UserCourses = courses;
            user.UserMaterial = materials;
            user.UserPerks = perks;
        }
    }
}
