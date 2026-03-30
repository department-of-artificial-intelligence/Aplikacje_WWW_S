using System;
using Microsoft.EntityFrameworkCore;
using lab2.Models;


public class AppDbContext : DbContext
{
	

    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }


}
