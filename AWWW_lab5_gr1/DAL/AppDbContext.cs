using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Definicje tabel w bazie danych
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<RoomEquipment> RoomEquipments { get; set; }

        // Konfiguracja (opcjonalna, jeśli konwencje nazewnictwa EF Core są zachowane, ale dobra praktyka)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // EF Core automatycznie wykryje relacje na podstawie kluczy obcych i właściwości nawigacyjnych,
            // ale możesz tutaj dodawać dodatkowe ograniczenia (np. maksymalne długości stringów, unikalne indeksy).
        }
    }
}