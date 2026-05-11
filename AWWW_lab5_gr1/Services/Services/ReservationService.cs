using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Reservation;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ReservationService : BaseService, IReservationService
    {
        public ReservationService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<ReservationDto>> GetAllAsync()
        {
            return await _dbContext.Reservations
                .AsNoTracking()
                .Include(r => r.Room)
                .Include(r => r.Event)
                .Select(r => new ReservationDto
                {
                    Id = r.Id,
                    RoomId = r.RoomId,
                    RoomName = r.Room.Name,
                    EventId = r.EventId,
                    EventTitle = r.Event.Title,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    Status = r.Status.ToString(),
                    Notes = r.Notes
                }).ToListAsync();
        }

        public async Task<ReservationDto?> GetByIdAsync(int id)
        {
            var r = await _dbContext.Reservations
                .AsNoTracking()
                .Include(r => r.Room)
                .Include(r => r.Event)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (r == null) return null;

            return new ReservationDto
            {
                Id = r.Id,
                RoomId = r.RoomId,
                RoomName = r.Room.Name,
                EventId = r.EventId,
                EventTitle = r.Event.Title,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                Status = r.Status.ToString(),
                Notes = r.Notes
            };
        }

        public async Task<int> CreateAsync(CreateReservationDto dto)
        {
            if (dto.EndTime <= dto.StartTime)
                throw new InvalidOperationException("Czas zakończenia musi być późniejszy niż czas rozpoczęcia.");

            if (!await CanRoomAccommodateEventAsync(dto.RoomId, dto.EventId))
                throw new InvalidOperationException("Wybrana sala jest za mała dla liczby uczestników tego wydarzenia.");

            if (await HasTimeConflictAsync(dto.RoomId, dto.StartTime, dto.EndTime))
                throw new InvalidOperationException("Sala jest już zarezerwowana w tym terminie.");

            var room = await _dbContext.Rooms.FindAsync(dto.RoomId);
            if (room == null || !room.IsActive)
                throw new InvalidOperationException("Wybrana sala nie istnieje lub jest nieaktywna.");

            var entity = new Reservation
            {
                RoomId = dto.RoomId,
                EventId = dto.EventId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Notes = dto.Notes,
                Status = ReservationStatus.Pending, 
                CreatedAt = DateTime.Now
            };

            _dbContext.Reservations.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateReservationDto dto)
        {
            var entity = await _dbContext.Reservations.FindAsync(dto.Id);
            if (entity == null) return false;

            if (dto.EndTime <= dto.StartTime)
                throw new InvalidOperationException("Czas zakończenia musi być późniejszy niż czas rozpoczęcia.");

            if (await HasTimeConflictAsync(dto.RoomId, dto.StartTime, dto.EndTime, dto.Id))
                throw new InvalidOperationException("Nowy termin koliduje z inną rezerwacją.");

            entity.RoomId = dto.RoomId;
            entity.EventId = dto.EventId;
            entity.StartTime = dto.StartTime;
            entity.EndTime = dto.EndTime;
            entity.Notes = dto.Notes;

            if (Enum.TryParse<ReservationStatus>(dto.Status, out var newStatus))
                entity.Status = newStatus;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Reservations.FindAsync(id);
            if (entity == null) return false;

            _dbContext.Reservations.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task<bool> HasTimeConflictAsync(int roomId, DateTime startTime, DateTime endTime, int? reservationId = null)
        {
            return await _dbContext.Reservations.AnyAsync(x =>
                x.RoomId == roomId &&
                (!reservationId.HasValue || x.Id != reservationId.Value) &&
                x.Status != ReservationStatus.Cancelled &&
                x.Status != ReservationStatus.Rejected &&
                startTime < x.EndTime &&
                endTime > x.StartTime);
        }

        private async Task<bool> CanRoomAccommodateEventAsync(int roomId, int eventId)
        {
            var room = await _dbContext.Rooms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == roomId);
            if (room == null) throw new InvalidOperationException("Wybrana sala nie istnieje.");

            var ev = await _dbContext.Events.AsNoTracking().FirstOrDefaultAsync(x => x.Id == eventId);
            if (ev == null) throw new InvalidOperationException("Wybrane wydarzenie nie istnieje.");

            return room.Capacity >= ev.ParticipantsLimit;
        }
    }
}