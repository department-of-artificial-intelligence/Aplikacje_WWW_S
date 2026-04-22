using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD

=======
using System.Data.Common;
>>>>>>> 9969e2a82d63e7fd425e5acd6f31e042fd7c69dc
namespace Kolokwium.Models
{
    public class AppDbContext : DbContext
    {
<<<<<<< HEAD
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
=======
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
>>>>>>> 9969e2a82d63e7fd425e5acd6f31e042fd7c69dc

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
<<<<<<< HEAD

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses);
        }
=======
        }

>>>>>>> 9969e2a82d63e7fd425e5acd6f31e042fd7c69dc
    }
}
