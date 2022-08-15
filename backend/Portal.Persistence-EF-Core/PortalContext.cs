using Microsoft.EntityFrameworkCore;
using Portal.Persistence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities;
using Portal.Persitence_EF_Core.FrameworkEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core
{
    internal class PortalContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Perk> Perks { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<CourseMaterial> CourseMaterials { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        public DbSet<UserMaterial> UserMaterials { get; set; }

        public DbSet<MaterialPerk> MaterialPerks { get; set; }

        public DbSet<UserPerk> UserPerks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=EducationalPortal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.AttendedCourses)
                .WithMany(c => c.Users);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedCourses)
                .WithOne(c => c.User);

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
