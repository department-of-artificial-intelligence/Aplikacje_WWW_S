using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

    }

}
