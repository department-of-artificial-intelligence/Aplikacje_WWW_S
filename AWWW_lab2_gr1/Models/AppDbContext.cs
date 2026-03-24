using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr1.Models 
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {}

        public DbSet<Address> Addresses {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<CustomerProfile> CustomerProfiles {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public DbSet<OrderItem> OrderItems {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Review> Reviews {get;set;}
        public DbSet<Tag> Tags {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderStatus)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderStatusId)
                .HasDefaultValue(1);

            modelBuilder.Entity<OrderStatusHistory>()
                .HasOne(h => h.Order)
                .WithMany(o => o.OrderStatusHistory)
                .HasForeignKey(h => h.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderStatusHistory>()
                .HasOne(h => h.OrderStatus)
                .WithMany(s => s.OrderStatusHistory)
                .HasForeignKey(h => h.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderStatus>()
                .HasData(
                    new OrderStatus { Id = 1, Name = "New" },
                    new OrderStatus { Id = 2, Name = "Paid" },
                    new OrderStatus { Id = 3, Name = "Shipped" },
                    new OrderStatus { Id = 4, Name = "Completed" }
                );
        }
    }
}
