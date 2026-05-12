using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Services.DTO.Reservation;
using Services.Interfaces;
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
            return await _dbContext.Reservations.AsNoTracking()
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<ReservationDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Reservations.Where(x => x.Id == id).AsNoTracking()
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateReservationDto dto)
        {
            await ValidateReservationAsync(dto.RoomId, dto.EventId, dto.StartTime, dto.EndTime);

            var entity = _mapper.Map<Reservation>(dto);
            entity.Status = ReservationStatus.Pending;
            entity.CreatedAt = DateTime.Now;

            _dbContext.Reservations.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateReservationDto dto)
        {
            var entity = await _dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;

            await ValidateReservationAsync(dto.RoomId, dto.EventId, dto.StartTime, dto.EndTime, dto.Id);

            _mapper.Map(dto, entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;

            _dbContext.Reservations.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        // --- Walidacje z poprzedniego zadania pozostają bez zmian ---
        private async Task ValidateReservationAsync(int roomId, int eventId, DateTime startTime, DateTime endTime, int? reservationId = null)
        {
            if (endTime <= startTime) throw new InvalidOperationException("Czas zakończenia musi być późniejszy niż czas rozpoczęcia.");
            var room = await _dbContext.Rooms.FindAsync(roomId);
            if (room == null) throw new InvalidOperationException("Sala nie istnieje.");
            if (!room.IsActive) throw new InvalidOperationException("Sala nie jest aktywna.");
            var canAccommodate = await CanRoomAccommodateEventAsync(roomId, eventId);
            if (!canAccommodate) throw new InvalidOperationException("Pojemność sali jest niewystarczająca.");
            var hasConflict = await HasTimeConflictAsync(roomId, startTime, endTime, reservationId);
            if (hasConflict) throw new InvalidOperationException("Rezerwacje tej samej sali nie mogą nakładać się w czasie.");
        }

        private async Task<bool> CanRoomAccommodateEventAsync(int roomId, int eventId)
        {
            var room = await _dbContext.Rooms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == roomId);
            if (room == null) throw new InvalidOperationException("Wybrana sala nie istnieje.");
            var ev = await _dbContext.Events.AsNoTracking().FirstOrDefaultAsync(x => x.Id == eventId);
            if (ev == null) throw new InvalidOperationException("Wybrane wydarzenie nie istnieje.");
            return room.Capacity >= ev.ParticipantsLimit;
        }

        private async Task<bool> HasTimeConflictAsync(int roomId, DateTime startTime, DateTime endTime, int? reservationId = null)
        {
            return await _dbContext.Reservations.AnyAsync(x =>
                x.RoomId == roomId &&
                (!reservationId.HasValue || x.Id != reservationId.Value) &&
                x.Status != ReservationStatus.Cancelled &&
                x.Status != ReservationStatus.Rejected &&
                startTime < x.EndTime && endTime > x.StartTime);
        }
    }
}