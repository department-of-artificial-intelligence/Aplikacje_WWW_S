using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2.v2_gr1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        { }

    public DbSet<Category> Address { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Order> Customer_Profile { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Order_Item> Order_Item { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Customer> Review { get; set; }
    public DbSet<Order_Item> Tag { get; set; }
    }
}