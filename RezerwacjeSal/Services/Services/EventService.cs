using DAL;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
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
        public EventService(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<EventDto>> GetAllAsync()
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Include(e => e.EventType)
                .OrderByDescending(e => e.CreatedAt)
                .ThenBy(e => e.Title)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    ParticipantsLimit = e.ParticipantsLimit,
                    IsPublic = e.IsPublic,
                    CreatedAt = e.CreatedAt,
                    EventTypeId = e.EventTypeId,
                    EventTypeName = e.EventType!.Name
                })
                .ToListAsync();
        }

        public async Task<List<EventDto>> GetPublicEventsAsync()
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Include(e => e.EventType)
                .Where(e => e.IsPublic)
                .OrderByDescending(e => e.CreatedAt)
                .ThenBy(e => e.Title)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    ParticipantsLimit = e.ParticipantsLimit,
                    IsPublic = e.IsPublic,
                    CreatedAt = e.CreatedAt,
                    EventTypeId = e.EventTypeId,
                    EventTypeName = e.EventType!.Name
                })
                .ToListAsync();
        }

        public async Task<List<EventDto>> GetByEventTypeIdAsync(int eventTypeId)
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Include(e => e.EventType)
                .Where(e => e.EventTypeId == eventTypeId)
                .OrderByDescending(e => e.CreatedAt)
                .ThenBy(e => e.Title)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    ParticipantsLimit = e.ParticipantsLimit,
                    IsPublic = e.IsPublic,
                    CreatedAt = e.CreatedAt,
                    EventTypeId = e.EventTypeId,
                    EventTypeName = e.EventType!.Name
                })
                .ToListAsync();
        }

        public async Task<EventDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Include(e => e.EventType)
                .Include(e => e.Reservations)
                    .ThenInclude(r => r.Room)
                .Where(e => e.Id == id)
                .Select(e => new EventDetailsDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    ParticipantsLimit = e.ParticipantsLimit,
                    IsPublic = e.IsPublic,
                    CreatedAt = e.CreatedAt,
                    EventTypeId = e.EventTypeId,
                    EventTypeName = e.EventType!.Name,
                    Reservations = e.Reservations.Select(r => new ReservationDto
                    {
                        Id = r.Id,
                        RoomId = r.RoomId,
                        RoomName = r.Room!.Name,
                        EventId = r.EventId,
                        EventTitle = r.Event!.Title,
                        StartTime = r.StartTime,
                        EndTime = r.EndTime,
                        Status = r.Status,
                        CreatedAt = r.CreatedAt,
                        Notes = r.Notes
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventDto dto)
        {
            var eventTypeExists = await _dbContext.EventTypes.AnyAsync(et => et.Id == dto.EventTypeId);
            if (!eventTypeExists)
                throw new InvalidOperationException("Wskazany typ wydarzenia nie istnieje.");

            if (dto.ParticipantsLimit <= 0)
                throw new InvalidOperationException("Liczba uczestników musi być większa od 0.");

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
            var eventTypeExists = await _dbContext.EventTypes.AnyAsync(et => et.Id == dto.EventTypeId);
            if (!eventTypeExists)
                throw new InvalidOperationException("Wskazany typ wydarzenia nie istnieje.");

            if (dto.ParticipantsLimit <= 0)
                throw new InvalidOperationException("Liczba uczestników musi być większa od 0.");

            var entity = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == dto.Id);
            if (entity == null)
                return false;

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
            var entity = await _dbContext.Events
                .Include(e => e.Reservations)
                .FirstOrDefaultAsync(e => e.Id == id);
                
            if (entity == null)
                return false;

            if (entity.Reservations.Any())
                throw new InvalidOperationException("Nie można usunąć wydarzenia, które posiada rezerwacje.");

            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
