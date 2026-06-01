using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Event;
using Services.DTO.Reservation;
using Services.Interfaces;
using Services.Services;

public class EventService : BaseService, IEventService
{
    public EventService(AppDbContext dbContext) : base(dbContext) { }

    public async Task<List<EventDto>> GetAllAsync()
    {
        return await _dbContext.Events
    .OrderByDescending(e => e.CreatedAt)
    .ThenBy(e => e.Title)
    .Select(e => new EventDto
    {
        Id = e.Id,
        Title = e.Title!,
        IsPublic = e.IsPublic,
        CreatedAt = e.CreatedAt
    })
    .ToListAsync();
    }

    public async Task<List<EventDto>> GetPublicEventAsync()
    {
        return await _dbContext.Events
    .Where(e => e.IsPublic)
    .OrderByDescending(e => e.CreatedAt)
    .ThenBy(e => e.Title)
    .Select(e => new EventDto
    {
        Id = e.Id,
        Title = e.Title!,
        IsPublic = e.IsPublic,
        CreatedAt = e.CreatedAt
    })
    .ToListAsync();
    }

    public async Task<List<EventDto>> GetByEventTypeIdAsync(int eventTypeId)
    {
        return await _dbContext.Events
    .Where(e => e.EventTypeId == eventTypeId)
    .OrderByDescending(e => e.CreatedAt)
    .ThenBy(e => e.Title)
    .Select(e => new EventDto
    {
        Id = e.Id,
        Title = e.Title!,
        IsPublic = e.IsPublic,
        CreatedAt = e.CreatedAt
    })
    .ToListAsync();
    }

    public async Task<EventDetailsDto?> GetByIdAsync(int id)
    {
        return await _dbContext.Events
            .Where(e => e.Id == id)
            .Select(e => new EventDetailsDto
            {
                Id = e.Id,
                Title = e.Title!,
                Description = e.Description!,
                ParticipantsLimit = e.ParticipantsLimit,
                IsPublic = e.IsPublic,
                CreatedAt = e.CreatedAt,

                EventTypeId = e.EventTypeId,
                EventTypeName = e.EventType!.Name!,

                Reservations = e.Reservations!.Select(r => new ReservationDto
                {
                    Id = r.Id
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateAsync(CreateEventDto dto)
    {
        if (dto.ParticipantsLimit <= 0)
        {
            throw new InvalidOperationException(
                "Participants limit must be greater than 0.");
        }

        if (!await _dbContext.EventTypes.AnyAsync(et => et.Id == dto.EventTypeId))
        {
            throw new InvalidOperationException(
                "Event type does not exist.");
        }

        var entity = new Event
        {
            Title = dto.Title,
            Description = dto.Description,
            ParticipantsLimit = dto.ParticipantsLimit,
            IsPublic = dto.IsPublic,
            EventTypeId = dto.EventTypeId,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Events.Add(entity);
        await _dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<bool> UpdateAsync(UpdateEventDto dto)
    {
        if (dto.ParticipantsLimit <= 0)
        {
            throw new InvalidOperationException(
                "Participants limit must be greater than 0.");
        }

        if (!await _dbContext.EventTypes.AnyAsync(et => et.Id == dto.EventTypeId))
        {
            throw new InvalidOperationException(
                "Event type does not exist.");
        }

        var entity = await _dbContext.Events.FindAsync(dto.Id);

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
        var entity = await _dbContext.Events.FindAsync(id);

        if (entity == null)
            return false;

        if (await _dbContext.Reservations.AnyAsync(r => r.EventId == id))
        {
            throw new InvalidOperationException(
                "Cannot delete event with reservations.");
        }

        _dbContext.Events.Remove(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}