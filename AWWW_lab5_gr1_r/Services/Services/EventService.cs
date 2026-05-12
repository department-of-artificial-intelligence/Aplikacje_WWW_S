using DAL;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Services.DTO.Event;
using Services.DTO.Reservation;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EventService : BaseService, IEventService
    {
        public EventService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<EventDto>> GetAllAsync()
        {
            return await _dbContext.Events
                .Include(x => x.EventType)
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ThenBy(x => x.Title)
                .Select(x => new EventDto
                {
                    Id = x.Id, Title = x.Title, ParticipantsLimit = x.ParticipantsLimit,
                    IsPublic = x.IsPublic, CreatedAt = x.CreatedAt, EventTypeName = x.EventType.Name
                }).ToListAsync();
        }

        public async Task<List<EventDto>> GetPublicEventsAsync()
        {
            return await _dbContext.Events
                .Include(x => x.EventType)
                .Where(x => x.IsPublic)
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ThenBy(x => x.Title)
                .Select(x => new EventDto
                {
                    Id = x.Id, Title = x.Title, ParticipantsLimit = x.ParticipantsLimit,
                    IsPublic = x.IsPublic, CreatedAt = x.CreatedAt, EventTypeName = x.EventType.Name
                }).ToListAsync();
        }

        public async Task<List<EventDto>> GetByEventTypeIdAsync(int eventTypeId)
        {
            return await _dbContext.Events
                .Include(x => x.EventType)
                .Where(x => x.EventTypeId == eventTypeId)
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ThenBy(x => x.Title)
                .Select(x => new EventDto
                {
                    Id = x.Id, Title = x.Title, ParticipantsLimit = x.ParticipantsLimit,
                    IsPublic = x.IsPublic, CreatedAt = x.CreatedAt, EventTypeName = x.EventType.Name
                }).ToListAsync();
        }

        public async Task<EventDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Events
                .Include(x => x.EventType)
                .Include(x => x.Reservations).ThenInclude(r => r.Room)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(x => new EventDetailsDto
                {
                    Id = x.Id, Title = x.Title, Description = x.Description, ParticipantsLimit = x.ParticipantsLimit,
                    IsPublic = x.IsPublic, CreatedAt = x.CreatedAt, EventTypeName = x.EventType.Name,
                    Reservations = x.Reservations.Select(r => new ReservationDto 
                    {
                        Id = r.Id, RoomId = r.RoomId, RoomName = r.Room.Name,
                        StartTime = r.StartTime, EndTime = r.EndTime, Status = r.Status
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventDto dto)
        {
            if (dto.ParticipantsLimit <= 0)
                throw new InvalidOperationException("Liczba uczestników musi być większa od 0.");

            if (!await _dbContext.EventTypes.AnyAsync(et => et.Id == dto.EventTypeId))
                throw new InvalidOperationException("Nie można utworzyć wydarzenia o nieistniejącym typie.");

            var entity = new Event
            {
                Title = dto.Title,
                Description = dto.Description,
                ParticipantsLimit = dto.ParticipantsLimit,
                IsPublic = dto.IsPublic,
                EventTypeId = dto.EventTypeId,
                CreatedAt = DateTime.Now
            };

            _dbContext.Events.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEventDto dto)
        {
            if (dto.ParticipantsLimit <= 0)
                throw new InvalidOperationException("Liczba uczestników musi być większa od 0.");

            if (!await _dbContext.EventTypes.AnyAsync(et => et.Id == dto.EventTypeId))
                throw new InvalidOperationException("Nie można zmienić typu wydarzenia na nieistniejący.");

            var entity = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.ParticipantsLimit = dto.ParticipantsLimit;
            entity.IsPublic = dto.IsPublic;
            entity.EventTypeId = dto.EventTypeId;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (await _dbContext.Reservations.AnyAsync(r => r.EventId == id))
                throw new InvalidOperationException("Nie można usunąć wydarzenia posiadającego rezerwacje.");

            var entity = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;

            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}