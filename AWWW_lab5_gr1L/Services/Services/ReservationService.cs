using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Reservation;
using Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ReservationService : BaseService, IReservationService
    {
        public ReservationService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<List<ReservationDto>> GetAllAsync()
        {
            return await _dbContext.Reservations
                .AsNoTracking()
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ReservationDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Reservations
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
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

            var entity = _mapper.Map<Reservation>(dto);

            entity.Status = ReservationStatus.Pending;
            entity.CreatedAt = DateTime.Now;

            if (string.IsNullOrEmpty(entity.Notes))
            {
                entity.Notes = "Brak uwag";
            }

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

            _mapper.Map(dto, entity);

            if (Enum.TryParse<ReservationStatus>(dto.Status, out var newStatus))
                entity.Status = newStatus;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateStatusAsync(int id, Model.ReservationStatus status)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);
            if (reservation == null)
            {
                throw new InvalidOperationException("Nie odnaleziono wskazanej rezerwacji.");
            }

            reservation.Status = status;
            await _dbContext.SaveChangesAsync();
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

        public async Task<List<ReservationDto>> GetByEventIdAsync(int eventId)
        {
            return await _dbContext.Reservations
                .AsNoTracking()
                .Where(r => r.EventId == eventId)
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}