using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Event;
using Services.DTO.Reservation;
using Services.Interfaces;
using Services.Services;
using AutoMapper.QueryableExtensions; // mapper

public class EventService : BaseService, IEventService
{
    public EventService(AppDbContext dbContext, IMapper mapper)
    : base(dbContext, mapper) { }

    public async Task<List<EventDto>> GetAllAsync()
    {
        return await _dbContext.Events
    .OrderByDescending(e => e.CreatedAt)
    .ThenBy(e => e.Title)
    .ProjectTo<EventDto>(_mapper.ConfigurationProvider)  //mapper
    .ToListAsync();
    }

    public async Task<List<EventDto>> GetPublicEventAsync()
    {
        return await _dbContext.Events
    .Where(e => e.IsPublic)
    .OrderByDescending(e => e.CreatedAt)
    .ThenBy(e => e.Title)
    .ProjectTo<EventDto>(_mapper.ConfigurationProvider)  //mapper
    .ToListAsync();
    }

    public async Task<List<EventDto>> GetByEventTypeIdAsync(int eventTypeId)
    {
        return await _dbContext.Events
    .Where(e => e.EventTypeId == eventTypeId)
    .OrderByDescending(e => e.CreatedAt)
    .ThenBy(e => e.Title)
    .ProjectTo<EventDto>(_mapper.ConfigurationProvider)  //mapper
    .ToListAsync();
    }

    public async Task<EventDetailsDto?> GetByIdAsync(int id)
    {
        return await _dbContext.Events
            .Where(e => e.Id == id)
            .ProjectTo<EventDetailsDto>(_mapper.ConfigurationProvider)  //mapper
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

        var entity = _mapper.Map<Event>(dto);  //mapper

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

        _mapper.Map(dto, entity);  //mapper

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