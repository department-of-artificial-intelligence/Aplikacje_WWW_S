using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        // table properties
        public DbSet<Grade>? Grades { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<SubjectGroup>? SubjectGroups { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //configuration commands
            optionsBuilder.UseLazyLoadingProxies(); //enable lazy loading proxies
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API commands
            modelBuilder.Entity<User>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<User>((int)RoleValue.User)
            .HasValue<Student>((int)RoleValue.Student)
            .HasValue<Parent>((int)RoleValue.Parent)
            .HasValue<Teacher>((int)RoleValue.Teacher);

            modelBuilder.Entity<SubjectGroup>()
            .HasKey(sg => new { sg.SubjectId, sg.GroupId });

            modelBuilder.Entity<SubjectGroup>()
            .HasOne(sg => sg.Subject)
            .WithMany(s => s.SubjectGroups)
            .HasForeignKey(sg => sg.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubjectGroup>()
            .HasOne(sg => sg.Group)
            .WithMany(s => s.SubjectGroups)
            .HasForeignKey(sg => sg.GroupId);

            modelBuilder.Entity<Grade>()
            .HasKey(g => new { g.DateOfIssue, g.SubjectId, g.StudentId });

            modelBuilder.Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(g => g.Students)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>()
            .HasOne(s => s.Parent)
            .WithMany(g => g.Students)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }

}