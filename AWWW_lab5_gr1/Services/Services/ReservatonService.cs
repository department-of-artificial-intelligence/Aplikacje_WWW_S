using DAL;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.Reservation;
using Services.Interfaces;

namespace Services.Services
{
    public class ReservationService : BaseService, IReservationService
    {
        public ReservationService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<ReservationListDto>> GetAllAsync()
        {
            return await _dbContext.Reservations.AsNoTracking().Select(x => new ReservationListDto
            {
                Id = x.Id,
                RoomName = x.Room.Name,
                EventTitle = x.Event.Title,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Status = x.Status
            }).ToListAsync();
        }

        public async Task<ReservationListDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Reservations.AsNoTracking().Where(x => x.Id == id).Select(x => new ReservationListDto
            {
                Id = x.Id,
                RoomName = x.Room.Name,
                EventTitle = x.Event.Title,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Status = x.Status
            }).FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateReservationDto dto)
        {
            await ValidateReservationRules(dto.RoomId, dto.EventId, dto.StartTime, dto.EndTime, null);

            var entity = new Model.DataModels.Reservation
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
            await ValidateReservationRules(dto.RoomId, dto.EventId, dto.StartTime, dto.EndTime, dto.Id);

            var entity = await _dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;

            entity.RoomId = dto.RoomId; entity.EventId = dto.EventId; entity.StartTime = dto.StartTime;
            entity.EndTime = dto.EndTime; entity.Status = dto.Status; entity.Notes = dto.Notes;
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

        private async Task ValidateReservationRules(int roomId, int eventId, DateTime startTime, DateTime endTime, int? reservationId)
        {
            if (endTime <= startTime) throw new InvalidOperationException("Czas zakończenia musi być późniejszy niż czas rozpoczęcia.");

            var room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == roomId);
            if (room == null) throw new InvalidOperationException("Sala nie istnieje.");
            if (!room.IsActive) throw new InvalidOperationException("Wybrana sala nie jest aktywna.");

            if (!await CanRoomAccommodateEventAsync(roomId, eventId))
                throw new InvalidOperationException("Wybrana sala nie pomieści maksymalnej liczby uczestników wydarzenia.");

            if (await HasTimeConflictAsync(roomId, startTime, endTime, reservationId))
                throw new InvalidOperationException("Konflikt czasowy - rezerwacje tej samej sali nie mogą się nakładać w czasie.");
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
                startTime < x.EndTime &&
                endTime > x.StartTime
            );
        }
    }
}