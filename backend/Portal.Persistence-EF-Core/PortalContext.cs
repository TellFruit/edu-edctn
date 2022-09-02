namespace Portal.Persistence_EF_Core
{
    internal class PortalContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Perk> Perks { get; set; }

        public DbSet<Material> Materials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = ConfigurationManager
                .ConnectionStrings["EducationalPortal"]
                .ConnectionString;

            optionsBuilder.UseSqlServer(connection);
        }

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
