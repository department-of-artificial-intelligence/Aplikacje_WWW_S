using Microsoft.EntityFrameworkCore;
using AWWW_lab2.v2_gr1.Models;

namespace AWWW_lab2.v2_gr1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}

