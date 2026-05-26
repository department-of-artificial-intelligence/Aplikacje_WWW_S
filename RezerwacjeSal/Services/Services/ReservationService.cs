using AutoMapper.QueryableExtensions;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
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
        public ReservationService(AppDbContext dbContext, AutoMapper.IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<ReservationDto>> GetAllAsync()
        {
            return await _dbContext.Reservations
                .AsNoTracking()
                .OrderByDescending(r => r.CreatedAt)
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ReservationDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Reservations
                .AsNoTracking()
                .Where(r => r.Id == id)
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateReservationDto dto)
        {
            if (dto.EndTime <= dto.StartTime)
                throw new InvalidOperationException("Czas zakończenia musi być późniejszy niż czas rozpoczęcia.");

            var room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == dto.RoomId);
            if (room == null)
                throw new InvalidOperationException("Wybrana sala nie istnieje.");

            if (!room.IsActive)
                throw new InvalidOperationException("Wybrana sala nie jest aktywna.");

            if (!await CanRoomAccommodateEventAsync(dto.RoomId, dto.EventId))
                throw new InvalidOperationException("Pojemność sali jest niewystarczająca dla wydarzenia.");

            if (await HasTimeConflictAsync(dto.RoomId, dto.StartTime, dto.EndTime))
                throw new InvalidOperationException("Istnieje konflikt czasowy z inną rezerwacją.");

            var entity = _mapper.Map<Reservation>(dto);
            entity.Status = ReservationStatus.Pending;
            entity.CreatedAt = DateTime.Now;

            _dbContext.Reservations.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateReservationDto dto)
        {
            if (dto.EndTime <= dto.StartTime)
                throw new InvalidOperationException("Czas zakończenia musi być późniejszy niż czas rozpoczęcia.");

            var room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == dto.RoomId);
            if (room == null)
                throw new InvalidOperationException("Wybrana sala nie istnieje.");

            if (!room.IsActive)
                throw new InvalidOperationException("Wybrana sala nie jest aktywna.");

            if (!await CanRoomAccommodateEventAsync(dto.RoomId, dto.EventId))
                throw new InvalidOperationException("Pojemność sali jest niewystarczająca dla wydarzenia.");

            if (await HasTimeConflictAsync(dto.RoomId, dto.StartTime, dto.EndTime, dto.Id))
                throw new InvalidOperationException("Istnieje konflikt czasowy z inną rezerwacją.");

            var entity = await _dbContext.Reservations.FirstOrDefaultAsync(r => r.Id == dto.Id);
            if (entity == null)
                return false;

            _mapper.Map(dto, entity);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            if (entity == null)
                return false;

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
                endTime > x.StartTime
            );
        }

        private async Task<bool> CanRoomAccommodateEventAsync(int roomId, int eventId)
        {
            var room = await _dbContext.Rooms
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == roomId);

            if (room == null)
                throw new InvalidOperationException("Wybrana sala nie istnieje.");

            var ev = await _dbContext.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == eventId);

            if (ev == null)
                throw new InvalidOperationException("Wybrane wydarzenie nie istnieje.");

            return room.Capacity >= ev.ParticipantsLimit;
        }
    }
}

