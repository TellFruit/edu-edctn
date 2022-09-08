namespace Portal.Persistence_EF_Core
{
    internal class PortalContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Perk> Perks { get; set; }

        public DbSet<Material> Materials { get; set; }

        public PortalContext(DbContextOptions<PortalContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>();
            modelBuilder.Entity<Book>();
            modelBuilder.Entity<Video>();

            modelBuilder.Entity<CourseMaterial>()
                .HasKey(x => new { x.CourseId, x.MaterialId });

            modelBuilder.Entity<UserCourse>()
                .HasKey(x => new { x.UserId, x.CourseId });

            modelBuilder.Entity<UserMaterial>()
                .HasKey(x => new { x.UserId, x.MaterialId });

            modelBuilder.Entity<CoursePerk>()
                .HasKey(x => new { x.PerkId, x.CourseId });

            modelBuilder.Entity<FrameworkEntities.UserPerk>()
                .HasKey(x => new { x.UserId, x.PerkId });
        }
    }
}
