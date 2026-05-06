using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
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

        public async Task<IList<ReservationDto>> GetAllAsync()
        {
            return await _dbContext.Reservations
                .AsNoTracking()
                .Select(r => new ReservationDto
                {
                    Id = r.Id,
                    RoomName = r.Room.Name,
                    EventTitle = r.Event.Title,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    Status = r.Status
                })
                .OrderByDescending(r => r.StartTime)
                .ToListAsync();
        }

        public async Task<ReservationDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Reservations
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new ReservationDetailsDto
                {
                    Id = r.Id,
                    RoomId = r.RoomId,
                    EventId = r.EventId,
                    RoomName = r.Room.Name,
                    EventTitle = r.Event.Title,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    Status = r.Status,
                    Notes = r.Notes,
                    CreatedAt = r.CreatedAt
                }).FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateReservationDto dto)
        {
            await ValidateReservationAsync(dto.RoomId, dto.EventId, dto.StartTime, dto.EndTime);

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

            //Walidacja biznesowa tylko jeśli zmienia się czas, sala lub wydarzenie
            await ValidateReservationAsync(dto.RoomId, dto.EventId, dto.StartTime, dto.EndTime, dto.Id);

            entity.RoomId = dto.RoomId;
            entity.EventId = dto.EventId;
            entity.StartTime = dto.StartTime;
            entity.EndTime = dto.EndTime;
            entity.Notes = dto.Notes;
            entity.Status = dto.Status;

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

        private async Task ValidateReservationAsync(int roomId, int eventId, DateTime start, DateTime end, int? reservationId = null)
        {
            //Czas zakończenia musi być późniejszy niż rozpoczęcia
            if (end <= start)
                throw new InvalidOperationException("Czas zakończenia musi być późniejszy niż rozpoczęcia.");

            //Sala musi istnieć i być aktywna
            var room = await _dbContext.Rooms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == roomId);
            if (room == null) throw new InvalidOperationException("Wybrana sala nie istnieje.");
            if (!room.IsActive) throw new InvalidOperationException("Wybrana sala jest nieaktywna.");

            //Sprawdzenie pojemności
            if (!await CanRoomAccommodateEventAsync(roomId, eventId))
                throw new InvalidOperationException("Sala nie posiada wystarczającej pojemności dla tego wydarzenia.");

            //Sprawdzenie konfliktów czasowych
            if (await HasTimeConflictAsync(roomId, start, end, reservationId))
                throw new InvalidOperationException("W wybranym terminie sala jest już zarezerwowana.");
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
