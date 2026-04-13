using Microsoft.EntityFrameworkCore;


namespace Kolokwium.Models
{
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}

    public DbSet<Ksiazka> Ksiazki { get; set; }
    public DbSet<Autor> Autorzy { get; set; }
    public DbSet<Biblioteka> Biblioteki { get; set; }

    /*

   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Ksiazka>()
        .HasOne(k => k.Biblioteka)
        .WithMany(b => b.Ksiazki)
        .HasForeignKey(k => k.BibliotekaId)
        .OnDelete(DeleteBehavior.Restrict);
}
        */
    
}
}