﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        // table properties
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectGroup> SubjectGroups { get; set; }
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
                .HasKey(k => new { k.GroupId, k.SubjectId });

            modelBuilder.Entity<SubjectGroup>()
                .HasOne(o => o.Group)
                .WithMany(sg => sg.SubjectGroups)
                .HasForeignKey(g => g.GroupId);

            modelBuilder.Entity<SubjectGroup>()
                .HasOne(o => o.Subject)
                .WithMany(sg => sg.SubjectGroups)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasKey(o => new { o.DateOfIssue, o.SubjectId, o.StudentId });

            modelBuilder.Entity<SubjectGroup>()
                .HasKey(o => new { o.SubjectId, o.GroupId });
        }
    }
}
