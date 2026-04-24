using DAL;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;
        public ReservationService(AppDbContext context) => _context = context;

        public string ValidateAndCreate(Reservation res)
        {
            if (res.EndTime <= res.StartTime)
                return "Błąd: Czas zakończenia musi być późniejszy niż rozpoczęcia.";

            var room = _context.Rooms.Find(res.RoomId);
            var @event = _context.Events.Find(res.EventId);

            if (@event.ParticipantsLimit > room.Capacity)
                return $"Błąd: Sala jest za mała! (Pojemność: {room.Capacity}, Uczestników: {@event.ParticipantsLimit})";

            bool isOverlapping = _context.Reservations.Any(existing =>
                existing.RoomId == res.RoomId &&
                res.StartTime < existing.EndTime &&
                existing.StartTime < res.EndTime);

            if (isOverlapping)
                return "Błąd: Sala jest już zajęta w tym terminie.";

            _context.Reservations.Add(res);
            _context.SaveChanges();
            return null; 
        }

        public IEnumerable<Reservation> GetAll() => _context.Reservations.Include(r => r.Room).Include(r => r.Event).ToList();
    }
}
