using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomEquipment> RoomsEquipment { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .Property(x => x.Status)
                .HasConversion<String>();

            modelBuilder.Entity<RoomEquipment>()
                .HasIndex(x => new { x.RoomId, x.EquipmentId })
                .IsUnique();

            modelBuilder.Entity<Room>()
                .HasOne<Building>(x => x.Building)
                .WithMany(x => x.Rooms)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne<Room>(x => x.Room)
                .WithMany()
                .HasForeignKey(x => x.RoomId);

            modelBuilder.Entity<Reservation>()
                .HasOne<Event>(x => x.Event)
                .WithMany()
                .HasForeignKey(x => x.EventId);

            modelBuilder.Entity<Event>()
                .HasOne<EventType>(x => x.EventType)
                .WithMany();


            modelBuilder.Entity<RoomEquipment>()
                .HasOne<Room>(x => x.Room)
                .WithMany();

            modelBuilder.Entity<RoomEquipment>()
                .HasOne<Equipment>(x => x.Equipment)
                .WithMany();
        }
    }
}
