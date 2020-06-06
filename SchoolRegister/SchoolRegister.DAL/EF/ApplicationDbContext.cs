using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        private readonly ConnectionStringDto _connectionStringDto;
        // Table properties e.g
        public virtual DbSet<Grade> Grade { get; set; }
        // other table properties
        // ……
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<SubjectGroup> SubjectGroup { get; set; }       
        
        public ApplicationDbContext(ConnectionStringDto connectionStringDto)
        {
            _connectionStringDto = connectionStringDto;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(_connectionStringDto.ConnectionString);
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
            .HasKey(sg => new { sg.GroupId, sg.SubjectId });

            modelBuilder.Entity<SubjectGroup>()
            .HasOne(g => g.Group)
            .WithMany(sg => sg.SubjectGroups)
            .HasForeignKey(g => g.GroupId);

            modelBuilder.Entity<SubjectGroup>()
            .HasOne(s => s.Subject)
            .WithMany(sg => sg.SubjectGroups)
            .HasForeignKey(s => s.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Group>()
                .Property(g => g.Name)
                .IsRequired();

            modelBuilder.Entity<Grade>()
                .HasKey(g => new { g.DateOfIssue, g.StudentId, g.SubjectId });

            modelBuilder.Entity<Grade>()
                .HasOne(s => s.Student)
                .WithMany(sg => sg.Grades)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
