namespace Portal.Persistence_EF_Core
{
    internal static class ContextExtension
    {
        public static void Configure(this ModelBuilder builder)
        {
            builder.Entity<Article>();
            builder.Entity<Book>();
            builder.Entity<Video>();

            builder.Entity<CourseMaterial>()
                .HasKey(x => new { x.CourseId, x.MaterialId });

            builder.Entity<UserCourse>()
                .HasKey(x => new { x.UserId, x.CourseId });

            builder.Entity<UserMaterial>()
                .HasKey(x => new { x.UserId, x.MaterialId });

            builder.Entity<CoursePerk>()
                .HasKey(x => new { x.PerkId, x.CourseId });

            builder.Entity<UserPerk>()
                .HasKey(x => new { x.UserId, x.PerkId });
        }

        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User 
                { 
                    Id = 9999,
                    Email = "admin@nix.dev.com",
                    Password = "admin",
                    Roles = "Admin"
                },
                new User
                {
                    Id = 9998,
                    Email = "moder1@nix.dev.com",
                    Password = "moder1",
                    Roles = "Moderator"
                });
        }
    }
}
