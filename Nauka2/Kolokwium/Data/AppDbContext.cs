using Microsoft.EntityFrameworkCore;
using Kolokwium.Models;


namespace Kolokwium.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Library)
                .WithMany(b => b.Books)
                .HasForeignKey(r => r.LibraryId)
                .OnDelete(DeleteBehavior.Restrict);

            //foreach (var fk in modelBuilder.Model.GetEntityTypes() Jak nie bede wiedzial ktoego na ktore dac restrict to moze uzyc tego na wszystkie
            //.SelectMany(e => e.GetForeignKeys()))
                 //   {
                     //   fk.DeleteBehavior = DeleteBehavior.Restrict;
                   // }

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }

    }
}
