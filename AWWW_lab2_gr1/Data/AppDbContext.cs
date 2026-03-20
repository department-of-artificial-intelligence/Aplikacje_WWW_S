using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Models;
using Azure;

namespace AWWW_lab2_gr1.Data
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