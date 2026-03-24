using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerProfile> CustomerProfiles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relacje dla statusów zamówienia
        modelBuilder.Entity<Order>()
            .HasOne(o => o.OrderStatus)
            .WithMany(s => s.Orders)
            .HasForeignKey(o => o.OrderStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderStatusHistory>()
            .HasOne(h => h.Order)
            .WithMany(o => o.OrderStatusHistories)
            .HasForeignKey(h => h.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderStatusHistory>()
            .HasOne(h => h.OrderStatus)
            .WithMany(s => s.OrderStatusHistories)
            .HasForeignKey(h => h.OrderStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        // Dodanie przykładowych kategorii
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Elektronika" },
            new Category { Id = 2, Name = "Odzież" },
            new Category { Id = 3, Name = "Książki" }
        );
    }
}