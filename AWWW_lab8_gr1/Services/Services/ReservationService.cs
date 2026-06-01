using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Reservation;
using Services.Interfaces;
using AutoMapper.QueryableExtensions; // mapper

namespace Services.Services
{
    internal class ReservationService : BaseService, IReservationService
    {
        public ReservationService(AppDbContext dbContext, IMapper mapper)
    : base(dbContext, mapper) { }

        public async Task<List<ReservationDto>> GetAllAsync()
        {
            return await _dbContext.Reservations
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)  //mapper
                .ToListAsync();
        }

        public async Task<List<ReservationDto>> GetByRoomIdAsync(int roomId)
        {
            return await _dbContext.Reservations
                .Where(r => r.RoomId == roomId)
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)  //mapper
                .ToListAsync();
        }

        public async Task<List<ReservationDto>> GetByEventIdAsync(int eventId)
        {
            return await _dbContext.Reservations
                .Where(r => r.EventId == eventId)
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)  //mapper
                .ToListAsync();
        }

        public async Task<ReservationDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Reservations
                .Where(r => r.Id == id)
                .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)  //mapper
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateReservationDto dto)
        {
            if (dto.EndTime <= dto.StartTime)
                throw new InvalidOperationException("End time must be after start time.");

            if (!await _dbContext.Rooms.AnyAsync(r => r.Id == dto.RoomId))
                throw new InvalidOperationException("Room does not exist.");

            if (!await _dbContext.Events.AnyAsync(e => e.Id == dto.EventId))
                throw new InvalidOperationException("Event does not exist.");

            if (await HasTimeConflictAsync(dto.RoomId, dto.StartTime, dto.EndTime))
                throw new InvalidOperationException("Room has time conflict.");

            if (!await CanRoomAccommodateEventAsync(dto.RoomId, dto.EventId))
                throw new InvalidOperationException("Room cannot accommodate event.");

            var entity = _mapper.Map<Reservation>(dto);  //mapper

            entity.CreatedAt = DateTime.UtcNow;  //mapper
            entity.Status = ReservationStatus.Pending;  //mapper

            _dbContext.Reservations.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateReservationDto dto)
        {
            var entity = await _dbContext.Reservations.FindAsync(dto.Id);

            if (entity == null)
                return false;

            if (dto.EndTime <= dto.StartTime)
                throw new InvalidOperationException("End time must be after start time.");

            if (!await _dbContext.Rooms.AnyAsync(r => r.Id == dto.RoomId))
                throw new InvalidOperationException("Room does not exist.");

            if (!await _dbContext.Events.AnyAsync(e => e.Id == dto.EventId))
                throw new InvalidOperationException("Event does not exist.");


            if (await HasTimeConflictAsync(dto.RoomId, dto.StartTime, dto.EndTime, dto.Id))
                throw new InvalidOperationException("Room has time conflict.");

            if (!await CanRoomAccommodateEventAsync(dto.RoomId, dto.EventId))
                throw new InvalidOperationException("Room cannot accommodate event.");

            _mapper.Map(dto, entity);  //mapper

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Reservations.FindAsync(id);

            if (entity == null)
                return false;

            _dbContext.Reservations.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        private async Task<bool> HasTimeConflictAsync(
            int roomId,
            DateTime startTime,
            DateTime endTime,
            int? reservationId = null)
        {
            return await _dbContext.Reservations.AnyAsync(x =>
                x.RoomId == roomId &&
                (!reservationId.HasValue || x.Id !=  reservationId.Value) &&
                x.Status != ReservationStatus.Cancelled &&
                x.Status != ReservationStatus.Rejected &&
                startTime < x.EndTime &&
                endTime > x.StartTime);
        }

        private async Task<bool> CanRoomAccommodateEventAsync(int roomId, int eventId)
        {
            var room = await _dbContext.Rooms
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == roomId);

            if (room == null)
                throw new InvalidOperationException("Room does not exist.");

            var ev = await _dbContext.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == eventId);

            if (ev == null)
                throw new InvalidOperationException("Event does not exist.");

            return room.Capacity >= ev.ParticipantsLimit;
        }
    }
}