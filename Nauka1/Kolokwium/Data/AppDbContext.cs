using Microsoft.EntityFrameworkCore;
using Kolokwium.Models;


namespace Kolokwium.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
               .HasOne(h => h.Hotel)
               .WithMany(r => r.Reservations)
               .HasForeignKey(h => h.HotelId)
               .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet <Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
