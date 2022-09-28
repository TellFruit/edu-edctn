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
            modelBuilder.Configure();

            modelBuilder.Seed();
        }
    }
}
