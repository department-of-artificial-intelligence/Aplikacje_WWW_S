using Microsoft.EntityFrameworkCore;

namespace AWWW_lab3_gr1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}