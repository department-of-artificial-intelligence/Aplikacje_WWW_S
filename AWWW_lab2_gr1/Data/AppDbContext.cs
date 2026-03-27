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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderStatusHistory>()
                .HasOne(h => h.Order)
                .WithMany(o => o.OrderStatusHistories)
                .HasForeignKey(h => h.OrderId)
                .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<OrderStatusHistory>()
                .HasOne(h => h.OrderStatus)
                .WithMany(s => s.OrderStatusHistories)
                .HasForeignKey(h => h.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict); 
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Address> Addresses { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
    }
}