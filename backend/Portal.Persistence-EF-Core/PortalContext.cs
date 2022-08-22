namespace Portal.Persistence_EF_Core
{
    internal class PortalContext : DbContext
    {
        private readonly IConfigService _config;

        public PortalContext(IConfigService configService)
        {
            _config = configService;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Perk> Perks { get; set; }

        public DbSet<Material> Materials { get; set; }

        //public DbSet<CourseMaterial> CourseMaterials { get; set; }

        //public DbSet<UserCourse> UserCourses { get; set; }

        //public DbSet<UserMaterial> UserMaterials { get; set; }

        //public DbSet<MaterialPerk> MaterialPerks { get; set; }

        //public DbSet<UserPerk> UserPerks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetSetting("DbConnectionString"));
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

            modelBuilder.Entity<MaterialPerk>()
                .HasKey(x => new { x.PerkId, x.MaterialId });

            modelBuilder.Entity<UserPerk>()
                .HasKey(x => new { x.UserId, x.PerkId });
        }
    }
}
