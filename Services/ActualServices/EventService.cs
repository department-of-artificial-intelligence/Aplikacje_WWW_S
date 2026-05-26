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

namespace Services.ActualServices {
    public class EventService : BaseService, IEventService {
        public EventService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<EventDTO>> GetAllAsync() {
            return await base._dbContext.Events
                .OrderBy(ev => ev.CreatedAt)
                .Select(ev => new EventDTO {
                    Id = ev.Id,
                    Title = ev.Title,
                    Description = ev.Description,
                    isPublic = ev.isPublic,
                    ParticipantsLimit = ev.ParticipantsLimit,
                    CreatedAt = ev.CreatedAt,
                    EventTypeId = ev.EventTypeId,
                })
                .ToListAsync();
        }

        public async Task<List<EventDTO>> GetPublicEventsAsync() {
            return await base._dbContext.Events
                .Where(ev => ev.isPublic)
                .OrderBy(ev => ev.CreatedAt)
                .Select(ev => new EventDTO {
                    Id = ev.Id,
                    Title = ev.Title,
                    Description = ev.Description,
                    isPublic = ev.isPublic,
                    ParticipantsLimit = ev.ParticipantsLimit,
                    CreatedAt = ev.CreatedAt,
                    EventTypeId = ev.EventTypeId
                })
                .ToListAsync();
        }

        public async Task<List<EventDTO>> GetByEventTypeIdAsync(int eventTypeId) {
            return await base._dbContext.Events
                .Where(ev => ev.EventTypeId == eventTypeId)
                .OrderBy(ev => ev.CreatedAt)
                .Select(ev => new EventDTO {
                    Id = ev.Id,
                    Title = ev.Title,
                    Description = ev.Description,
                    isPublic = ev.isPublic,
                    ParticipantsLimit = ev.ParticipantsLimit,
                    CreatedAt = ev.CreatedAt,
                    EventTypeId = ev.EventTypeId
                })
                .ToListAsync();
        }

        public async Task<EventDetailsDTO?> GetByIdAsync(int id) {
            Event ev = await base._dbContext.Events.FindAsync(id);
            
            if (ev == null) return null;
            
            EventDetailsDTO dto = new EventDetailsDTO();
            dto.Id = id;
            dto.Title = ev.Title;
            dto.Description = ev.Description;
            dto.isPublic = ev.isPublic;
            dto.ParticipantsLimit = ev.ParticipantsLimit;
            dto.CreatedAt = ev.CreatedAt;
            dto.EventTypeId = ev.EventTypeId;

            dto.Reservations = await base._dbContext
                .Reservations
                .Where(re => re.EventId == id)
                .OrderBy(re => re.CreatedAt)
                .Select(re => new ReservationDTO {
                    Id = re.Id,
                    StartTime = re.StartTime,
                    EndTime = re.EndTime,
                    CreatedAt = re.CreatedAt,
                    Notes = re.Notes
                }).ToListAsync();
            return dto;
        }

        public async Task<int> CreateAsync(CreateEventDTO dto)
        {
            Event e = new Event();

            if (dto.ParticipantsLimit <= 0)
            {
                throw new InvalidOperationException("Participant limit can not be non-positive");
            }

            e.ParticipantsLimit = dto.ParticipantsLimit;

            if (await base._dbContext.EventTypes.FindAsync(dto.EventTypeId) == null)
            {
                throw new InvalidOperationException("Invalid event type.");
            }

            e.EventTypeId = dto.EventTypeId;

            e.Title = dto.Title;
            e.Description = dto.Description;

            e.isPublic = dto.isPublic;

            base._dbContext.Events.AddAsync(e);
            await base._dbContext.SaveChangesAsync();

            return e.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEventDTO dto) {
            Event e = await base._dbContext.Events.FindAsync(dto.Id);

            if (e == null) return false;

            e.Description = dto.Description;
            e.Title = dto.Title;
            e.isPublic = dto.isPublic;

            if (dto.ParticipantsLimit <= 0)
            {
                throw new InvalidOperationException("Participant limit can not be non-positive");
            }

            e.ParticipantsLimit = dto.ParticipantsLimit;

            if (await base._dbContext.EventTypes.FindAsync(dto.EventTypeId) == null)
            {
                throw new InvalidOperationException("Invalid event type.");
            }

            e.EventTypeId = dto.EventTypeId;

            return await base._dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Event e = await base._dbContext.Events.FindAsync(id);

            if (e == null) return false;

            base._dbContext.Events.Remove(e);
            return await base._dbContext.SaveChangesAsync() > 0;
        }
    }
}
