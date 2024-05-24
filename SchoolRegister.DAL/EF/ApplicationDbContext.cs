using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Model.DataModels;

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

// Definicja klucza głównego złożonego dla encji SubjectGroup
    modelBuilder.Entity<SubjectGroup>()
        .HasKey(sg => new { sg.SubjectId, sg.GroupId });

    // Definicja klucza obcego z SubjectGroup (GroupId) do tabeli Groups (Id)
    modelBuilder.Entity<SubjectGroup>()
        .HasOne(sg => sg.Group)
        .WithMany(g => g.SubjectGroups)
        .HasForeignKey(sg => sg.GroupId)
        .OnDelete(DeleteBehavior.Restrict); // Definicja reakcji na usunięcie encji OnDelete – Restrict

    // Definicja klucza obcego z SubjectGroup (SubjectId) do tabeli Subjects (Id)
    modelBuilder.Entity<SubjectGroup>()
        .HasOne(sg => sg.Subject)
        .WithMany(s => s.SubjectGroups)
        .HasForeignKey(sg => sg.SubjectId)
        .OnDelete(DeleteBehavior.Restrict); // Definicja reakcji na usunięcie encji OnDelete – Restrict
}


}