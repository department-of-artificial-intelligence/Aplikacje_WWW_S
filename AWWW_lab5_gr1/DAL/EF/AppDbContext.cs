using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<RoomEquipment> RoomEquipments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .Property(x => x.Status)
                .HasConversion<string>();

            modelBuilder.Entity<RoomEquipment>()
                .HasIndex(x => new { x.RoomId, x.EquipmentId })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
