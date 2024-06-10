using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SchoolRegister.Model.DataModels;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Proxies;

namespace SchoolRegister.DAL.EF
{
    public class ApplicationDbContext: IdentityDbContext<User, Role, int> 
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups {get; set;}
        public DbSet<Subject> Subjects {get; set;}
        public DbSet<SubjectGroup> SubjectGroups {get; set;}

        public DbSet<Teacher> Teachers {get; set;}

        public DbSet<Student> Students {get; set;}
        public DbSet<Parent> Parents {get; set;}
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            base.OnConfiguring(optionsBuilder); 

            optionsBuilder.UseLazyLoadingProxies(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<User>()
                .ToTable("AspNetUsers")
                .HasDiscriminator<int>("UserType")
                .HasValue<User>((int)RoleValue.User)
                .HasValue<Student>((int)RoleValue.Student)
                .HasValue<Parent>((int)RoleValue.Parent)
                .HasValue<Teacher>((int)RoleValue.Teacher);

        // Subject Group
            modelBuilder.Entity<SubjectGroup>()
                .HasKey(sg => new {sg.GroupId, sg.SubjectId});

            modelBuilder.Entity<SubjectGroup>()
                .HasOne(g => g.Group)
                .WithMany(sg => sg.SubjectGroups)
                .HasForeignKey(g => g.GroupId);

            modelBuilder.Entity<SubjectGroup>()
                .HasOne(g => g.Subject)
                .WithMany(s => s.SubjectGroups)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

        // Grade
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId );
            
            modelBuilder.Entity<Grade>()
                .HasKey(g => new {g.DateOfIssue, g.SubjectId, g.StudentId}); 

        // Subject
            modelBuilder.Entity<Subject>()
                .HasKey(s => s.Id); 
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(s => s.TeacherId);
            
        // Group
            modelBuilder.Entity<Group>()
                .HasKey(g => g.Id); 
        
            

        }
    }
}