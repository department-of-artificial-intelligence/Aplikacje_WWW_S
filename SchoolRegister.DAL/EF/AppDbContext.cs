using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Model.DataModels;


namespace SchoolRegister.DAL.EF {
    public class AppDbContext : IdentityDbContext<User,Role,int>
    {
        public DbSet<Grade> Grades {get;set;}
        public DbSet<Group> Groups {get;set;}
        public DbSet<Subject> Subjects {get;set;}
        public DbSet<SubjectGroup> SubjectGroups {get;set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies(); // enable lazy loading proxies
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .ToTable("AspNetUsers")
                .HasDiscriminator<int>("UserType")
                .HasValue<User>((int)RoleValue.User)
                .HasValue<Student>((int)RoleValue.Student)
                .HasValue<Parent>((int)RoleValue.Parent)
                .HasValue<Teacher>((int)RoleValue.Teacher);

            builder.Entity<SubjectGroup>()
                .HasKey(sg => new {sg.GroupId, sg.SubjectId});

            builder.Entity<SubjectGroup>()
                .HasOne(g=>g.Group)
                .WithMany(sg=>sg.SubjectGroups)
                .HasForeignKey(g=>g.GroupId);

            builder.Entity<SubjectGroup>()
                .HasOne(s=>s.Subject)
                .WithMany(sg=>sg.SubjectGroups)
                .HasForeignKey(s=>s.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
