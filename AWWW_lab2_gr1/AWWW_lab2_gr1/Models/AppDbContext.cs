using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }


        //To nie jest must have ale przydaje sie przy relacjach 1:1 i N:M bo EntityFramework moze sie ciulnac i zrobic zle, reszte ogarnie EF
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1:1 Customer - CustomerProfile
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.CustomerProfile)
                .WithOne(cp => cp.Customer)
                .HasForeignKey<CustomerProfile>(cp => cp.CustomerId);

            //N:M Product - Tag (automatyczna tabela)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Products);

            //Order - OrderStatus (N:1)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderStatus)
                .WithMany(os => os.Orders)
                .HasForeignKey(o => o.OrderStatusId);

            //historia nie powinna się usuwać automatycznie ↓

            //Order - OrderStatusHistory (1:N)
            modelBuilder.Entity<OrderStatusHistory>()
                .HasOne(osh => osh.Order)
                .WithMany(o => o.OrderStatusHistories)
                .HasForeignKey(osh => osh.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            //OrderStatus - OrderStatusHistory (1:N)
            modelBuilder.Entity<OrderStatusHistory>()
                .HasOne(osh => osh.OrderStatus)
                .WithMany(os => os.OrderStatusHistories)
                .HasForeignKey(osh => osh.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
