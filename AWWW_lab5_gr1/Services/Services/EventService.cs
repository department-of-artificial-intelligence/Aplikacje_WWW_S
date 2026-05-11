using DAL;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.Event;
using Services.Interfaces;

namespace Services.Services
{
    public class EventService : BaseService, IEventService
    {
        public EventService(AppDbContext dbContext) : base(dbContext) { }

        private IQueryable<Model.DataModels.Event> GetBaseQuery()
        {
            return _dbContext.Events
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ThenBy(x => x.Title);
        }

        public async Task<List<EventDto>> GetAllAsync()
        {
            return await GetBaseQuery().Select(x => new EventDto
            {
                Id = x.Id,
                Title = x.Title,
                EventTypeName = x.EventType.Name,
                ParticipantsLimit = x.ParticipantsLimit,
                IsPublic = x.IsPublic,
                CreatedAt = x.CreatedAt
            }).ToListAsync();
        }

        public async Task<List<EventDto>> GetPublicEventsAsync()
        {
            return await GetBaseQuery().Where(x => x.IsPublic).Select(x => new EventDto
            {
                Id = x.Id,
                Title = x.Title,
                EventTypeName = x.EventType.Name,
                ParticipantsLimit = x.ParticipantsLimit,
                IsPublic = x.IsPublic,
                CreatedAt = x.CreatedAt
            }).ToListAsync();
        }

        public async Task<List<EventDto>> GetByEventTypeIdAsync(int eventTypeId)
        {
            return await GetBaseQuery().Where(x => x.EventTypeId == eventTypeId).Select(x => new EventDto
            {
                Id = x.Id,
                Title = x.Title,
                EventTypeName = x.EventType.Name,
                ParticipantsLimit = x.ParticipantsLimit,
                IsPublic = x.IsPublic,
                CreatedAt = x.CreatedAt
            }).ToListAsync();
        }

        public async Task<EventDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Events.AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new EventDetailsDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    EventTypeName = x.EventType.Name,
                    ParticipantsLimit = x.ParticipantsLimit,
                    IsPublic = x.IsPublic,
                    CreatedAt = x.CreatedAt,
                    Reservations = x.Reservations.Select(r => new ReservationDto
                    {
                        Id = r.Id,
                        RoomName = r.Room.Name,
                        StartTime = r.StartTime,
                        EndTime = r.EndTime,
                        Status = r.Status
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventDto dto)
        {
            if (dto.ParticipantsLimit <= 0) throw new InvalidOperationException("Liczba uczestnikow musi byc wieksza od 0.");
            if (!await _dbContext.EventTypes.AnyAsync(et => et.Id == dto.EventTypeId)) throw new InvalidOperationException("Wybrany typ wydarzenia nie istnieje.");

            var entity = new Model.DataModels.Event
            {
                Title = dto.Title,
                Description = dto.Description,
                EventTypeId = dto.EventTypeId,
                ParticipantsLimit = dto.ParticipantsLimit,
                IsPublic = dto.IsPublic,
                CreatedAt = DateTime.Now
            };

            _dbContext.Events.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEventDto dto)
        {
            if (dto.ParticipantsLimit <= 0) throw new InvalidOperationException("Liczba uczestników musi być większa od 0.");
            if (!await _dbContext.EventTypes.AnyAsync(et => et.Id == dto.EventTypeId)) throw new InvalidOperationException("Wybrany typ wydarzenia nie istnieje.");

            var entity = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;

            entity.Title = dto.Title; entity.Description = dto.Description; entity.EventTypeId = dto.EventTypeId;
            entity.ParticipantsLimit = dto.ParticipantsLimit; entity.IsPublic = dto.IsPublic;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hasReservations = await _dbContext.Reservations.AnyAsync(r => r.EventId == id);
            if (hasReservations) throw new InvalidOperationException("Nie można usunąć wydarzenia powiązanego z rezerwacjami.");

            var entity = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;

            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}