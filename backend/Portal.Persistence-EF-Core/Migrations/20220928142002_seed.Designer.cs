// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portal.Persistence_EF_Core;

#nullable disable

namespace Portal.Persistence_EF_Core.Migrations
{
    [DbContext(typeof(PortalContext))]
    [Migration("20220928142002_seed")]
    partial class seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.Abstract.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Materials");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Material");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.CourseMaterial", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("CourseMaterial");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.CoursePerk", b =>
                {
                    b.Property<int>("PerkId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("PerkId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CoursePerk");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.Perk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Perks");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1000,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@nix.dev.com",
                            Password = "admin",
                            Roles = "Admin",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 1001,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "moder1@nix.dev.com",
                            Password = "moder1",
                            Roles = "Moderator",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.UserCourse", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserCourse");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.UserMaterial", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("UserMaterial");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.UserPerk", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("PerkId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("UserId", "PerkId");

                    b.HasIndex("PerkId");

                    b.ToTable("UserPerk");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.Article", b =>
                {
                    b.HasBaseType("Portal.Persistence_EF_Core.FrameworkEntities.Abstract.Material");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Article");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.Book", b =>
                {
                    b.HasBaseType("Portal.Persistence_EF_Core.FrameworkEntities.Abstract.Material");

                    b.Property<string>("Authors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime2")
                        .HasColumnName("Book_Published");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.Video", b =>
                {
                    b.HasBaseType("Portal.Persistence_EF_Core.FrameworkEntities.Abstract.Material");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.Course", b =>
                {
                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.CourseMaterial", b =>
                {
                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.Course", "Course")
                        .WithMany("CourseMaterials")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.Abstract.Material", "Material")
                        .WithMany("CourseMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.CoursePerk", b =>
                {
                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.Course", "Course")
                        .WithMany("CoursePerks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.Perk", "Perk")
                        .WithMany("CoursePerks")
                        .HasForeignKey("PerkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Perk");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.UserCourse", b =>
                {
                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.UserMaterial", b =>
                {
                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.Abstract.Material", "Material")
                        .WithMany("UserMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.User", "User")
                        .WithMany("UserMaterial")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.UserPerk", b =>
                {
                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.Perk", "Perk")
                        .WithMany("UserPerks")
                        .HasForeignKey("PerkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Persistence_EF_Core.FrameworkEntities.User", "User")
                        .WithMany("UserPerks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perk");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.Abstract.Material", b =>
                {
                    b.Navigation("CourseMaterials");

                    b.Navigation("UserMaterials");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.Course", b =>
                {
                    b.Navigation("CourseMaterials");

                    b.Navigation("CoursePerks");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.Perk", b =>
                {
                    b.Navigation("CoursePerks");

                    b.Navigation("UserPerks");
                });

            modelBuilder.Entity("Portal.Persistence_EF_Core.FrameworkEntities.User", b =>
                {
                    b.Navigation("UserCourses");

                    b.Navigation("UserMaterial");

                    b.Navigation("UserPerks");
                });
#pragma warning restore 612, 618
        }
    }
}
