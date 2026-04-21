using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> o) : base(o) { }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Address> Addresses { get; set; }

}