using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Event;
using Services.DTO.Reservation;
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

        public async Task<IList<EventDto>> GetAllAsync()
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Name = e.Title,
                    TypeName = e.EventType.Name,
                    IsPublic = e.IsPublic,
                    CreatedAt = e.CreatedAt
                })
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }

        public async Task<IList<EventDto>> GetPublicEventsAsync()
        {
            return await _dbContext.Events
                .Where(e => e.IsPublic)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Name = e.Title,
                    TypeName = e.EventType.Name,
                    IsPublic = e.IsPublic,
                    CreatedAt = e.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<IList<EventDto>> GetByEventTypeIdAsync(int eventTypeId)
        {
            return await _dbContext.Events
                .Where(e => e.EventTypeId == eventTypeId)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Name = e.Title,
                    TypeName = e.EventType.Name,
                    IsPublic = e.IsPublic,
                    CreatedAt = e.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<EventDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new EventDetailsDto
                {
                    Id = e.Id,
                    Name = e.Title,
                    Description = e.Description,
                    TypeName = e.EventType.Name,
                    CreatedAt = e.CreatedAt,
                    Reservations = e.Reservations.Select(r => new ReservationDto
                    {
                        Id = r.Id,
                        RoomName = r.Room.Name,
                        StartTime = r.StartTime,
                        EndTime = r.EndTime
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventDto dto)
        {
            if (dto.ParticipantsLimit <= 0)
                throw new InvalidOperationException("Limit musi być > 0");

            var entity = new Event
            {
                Title = dto.Name,
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
            var entity = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == dto.Id);
            if (entity == null) return false;

            entity.Title = dto.Name;
            entity.Description = dto.Description;
            entity.EventTypeId = dto.EventTypeId;
            entity.ParticipantsLimit = dto.ParticipantsLimit;
            entity.IsPublic = dto.IsPublic;

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
                throw new InvalidOperationException("Nie można usunąć wydarzenia z istniejącymi rezerwacjami.");

            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task ValidateTypeAsync(int typeId)
        {
            if (!await _dbContext.EventsType.AnyAsync(x => x.Id == typeId))
                throw new InvalidOperationException("Wybrany typ wydarzenia nie istnieje.");
        }
    }
}