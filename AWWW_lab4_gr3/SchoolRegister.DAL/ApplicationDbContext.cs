using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Model.DataModels;

public class ApplicationDbContext : IdentityDbContext<User, Role, int> 
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<SubjectGroup> SubjectGroups { get; set; }
    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); 
        builder.Entity<Parent>()
            .HasMany(p => p.Students)
            .WithOne(s => s.Parent)
            .HasForeignKey(s => s.ParentId)
            .OnDelete(DeleteBehavior.Restrict); 

        builder.Entity<Group>()
            .HasMany(g => g.Students)
            .WithOne(s => s.Group)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Restrict); 

        builder.Entity<Teacher>()
            .HasMany(t => t.Subjects)
            .WithOne(s => s.Teacher)
            .HasForeignKey(s => s.TeacherId)
            .OnDelete(DeleteBehavior.SetNull); 

        builder.Entity<Student>()
            .HasMany(s => s.Grades)
            .WithOne(g => g.Student)
            .HasForeignKey(g => g.StudentId)
            .OnDelete(DeleteBehavior.Cascade); 

       
        builder.Entity<Subject>()
            .HasMany(s => s.Grades)
            .WithOne(g => g.Subject)
            .HasForeignKey(g => g.SubjectId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.Entity<SubjectGroup>()
            .HasKey(sg => sg.Id); 

        builder.Entity<SubjectGroup>()
            .HasOne(sg => sg.Subject)
            .WithMany(s => s.SubjectGroups)
            .HasForeignKey(sg => sg.SubjectId);

        builder.Entity<SubjectGroup>()
            .HasOne(sg => sg.Group)
            .WithMany(g => g.SubjectGroups)
            .HasForeignKey(sg => sg.GroupId);

      
    }
}