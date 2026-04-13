using Microsoft.EntityFrameworkCore;
using AWWW_lab3_gr1.Models;

namespace AWWW_lab3_gr1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerProfile> CustomerProfiles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.OrderStatus)
            .WithMany(os => os.Orders)
            .HasForeignKey(o => o.OrderStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderStatusHistory>()
            .HasOne(osh => osh.Order)
            .WithMany(o => o.StatusHistory)
            .HasForeignKey(osh => osh.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderStatusHistory>()
            .HasOne(osh => osh.OrderStatus)
            .WithMany(os => os.StatusHistories)
            .HasForeignKey(osh => osh.OrderStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}