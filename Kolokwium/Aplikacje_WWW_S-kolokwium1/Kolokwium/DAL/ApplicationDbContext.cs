using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models{

    public class AplicationDbContext:DbContext{
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options):base(options){

        }
        public DbSet<Order> Orders{get;set;}
        public Address DeliveryAddress{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(o => o.Meals).WithMany(z => z.Orders);

            modelBuilder.Entity<Order>().HasOne(o => o.DeliveryAddress).WithMany(z => z.Orders);

            base.OnModelCreating(modelBuilder);
        }
}
}