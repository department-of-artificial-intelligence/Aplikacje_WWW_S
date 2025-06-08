using Microsoft.EntityFrameworkCore;
using Kolokwium.Models;

public class MyDbContext : DbContext{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Garage> Garages  { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Car>()
            .HasOne(m => m.Garage)
            .WithMany(t => t.Cars)
            .HasForeignKey(m => m.GarageId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Owner>()
            .HasOne(m => m.Garage)
            .WithOne(t => t.Owner)
            .HasForeignKey<Garage>(m => m.OwnerId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
//ciekawe czy dziala
