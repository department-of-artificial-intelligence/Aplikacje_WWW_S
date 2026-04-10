using Microsoft.EntityFrameworkCore;

namespace AWWW_lab4_gr1.Models
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
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne<OrderStatus>()
                .WithMany()
                .HasForeignKey(o => o.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderStatusHistory>()
                .HasOne<Order>()
                .WithMany()
                .HasForeignKey(h => h.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderStatusHistory>()
                .HasOne<OrderStatus>()
                .WithMany()
                .HasForeignKey(h => h.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}