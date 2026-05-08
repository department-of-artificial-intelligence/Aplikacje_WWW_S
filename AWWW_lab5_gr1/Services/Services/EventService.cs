using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Event;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EventService : BaseService, IEventService
    {
        public EventService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<EventDto>> GetAllAsync()
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Include(e => e.EventType)
                .OrderByDescending(e => e.CreatedAt)
                .ThenBy(e => e.Title)
                .Select(e => MapToDto(e))
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
                .Select(e => MapToDto(e))
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
                .Select(e => MapToDto(e))
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
                    CreatedAt = e.CreatedAt,
                    IsPublic = e.IsPublic,
                    ParticipantsLimit = e.ParticipantsLimit,
                    EventTypeName = e.EventType.Name,
                    Reservations = e.Reservations.Select(r => new ReservationDto
                    {
                        Id = r.Id,
                        RoomName = r.Room.Name,
                        StartTime = r.StartTime,
                        EndTime = r.EndTime,
                        Status = r.Status.ToString()
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventDto dto)
        {
            if (dto.ParticipantsLimit <= 0)
                throw new InvalidOperationException("Liczba uczestników musi być większa od 0.");

            var typeExists = await _dbContext.EventsType.AnyAsync(t => t.Id == dto.EventTypeId);
            if (!typeExists)
                throw new InvalidOperationException("Wybrany typ wydarzenia nie istnieje.");

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

            var entity = await _dbContext.Events.FindAsync(dto.Id);
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
            var entity = await _dbContext.Events
                .Include(e => e.Reservations)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null) return false;

            if (entity.Reservations.Any())
                throw new InvalidOperationException("Nie można usunąć wydarzenia, które posiada przypisane rezerwacje.");

            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private static EventDto MapToDto(Event e)
        {
            return new EventDto
            {
                Id = e.Id,
                Title = e.Title,
                EventTypeName = e.EventType?.Name ?? "Nieznany",
                CreatedAt = e.CreatedAt,
                IsPublic = e.IsPublic
            };
        }
    }
}
