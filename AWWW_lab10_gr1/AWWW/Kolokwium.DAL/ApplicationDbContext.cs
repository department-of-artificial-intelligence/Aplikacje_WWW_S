using Kolokwium.Model.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        // table properties
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; } 
        public virtual DbSet<Product> Products { get; set; } 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //configuration commands            
            optionsBuilder.UseLazyLoadingProxies(); //enable lazy loading proxies
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API commands
           /*modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired();

            // Konfiguracja Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();

            // Relacja 1:n (Category -> Product)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Relacja n:n (Product <-> Tag)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Products)
                .UsingEntity(j => j.ToTable("ProductTags"));

            // Konfiguracja Tag
            modelBuilder.Entity<Tag>()
                .Property(t => t.Name)
                .IsRequired();*/
        }
    }
}
