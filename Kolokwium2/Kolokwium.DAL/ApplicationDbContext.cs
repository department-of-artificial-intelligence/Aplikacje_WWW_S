using Kolokwium.Model.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        // table properties
        // public virtual DbSet<Entity> TableName { get; set; } = null!;
        public virtual DbSet<Biblioteka> Biblioteki { get; set; } = null!;
        public virtual DbSet<Ksiazka> Ksiazki { get; set; } = null!;
        public virtual DbSet<Autor> Autorzy { get; set; } = null!;

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
            modelBuilder.Entity<Ksiazka>()
                .HasOne(k => k.Autor)
                .WithMany(a => a.Ksiazki)
                .HasForeignKey(k => k.AutorId);

            modelBuilder.Entity<Ksiazka>()
                .HasOne(k => k.Wydawnictwo)
                .WithMany(w => w.Ksiazki)
                .HasForeignKey(k => k.WydawnictwoId);
           
        }
    }
}
