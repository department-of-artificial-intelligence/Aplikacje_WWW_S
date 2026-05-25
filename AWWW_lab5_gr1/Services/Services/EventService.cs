using DAL;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.Event;
using Services.Interfaces;

namespace Services.Services
{
    public class EventService : BaseService, IEventService
    {
        public EventService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        private IQueryable<Event> GetBaseQuery()
        {
            return _dbContext.Events
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ThenBy(x => x.Title);
        }

        public async Task<List<EventDto>> GetAllAsync()
        {
            return await GetBaseQuery()
                .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<EventDto>> GetPublicEventsAsync()
        {
            return await GetBaseQuery()
                .Where(x => x.IsPublic)
                .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<EventDto>> GetByEventTypeIdAsync(int eventTypeId)
        {
            return await GetBaseQuery()
                .Where(x => x.EventTypeId == eventTypeId)
                .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<EventDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<EventDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventDto dto)
        {
            if (dto.ParticipantsLimit <= 0)
                throw new InvalidOperationException("Liczba uczestników musi być większa od 0.");
            if (!await _dbContext.EventTypes.AnyAsync(et => et.Id == dto.EventTypeId))
                throw new InvalidOperationException("Wybrany typ wydarzenia nie istnieje.");

            var entity = _mapper.Map<Event>(dto);
            entity.CreatedAt = DateTime.Now;

            _dbContext.Events.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEventDto dto)
        {
            if (dto.ParticipantsLimit <= 0)
                throw new InvalidOperationException("Liczba uczestników musi być większa od 0.");
            if (!await _dbContext.EventTypes.AnyAsync(et => et.Id == dto.EventTypeId))
                throw new InvalidOperationException("Wybrany typ wydarzenia nie istnieje.");

            var entity = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hasReservations = await _dbContext.Reservations.AnyAsync(r => r.EventId == id);
            if (hasReservations)
                throw new InvalidOperationException("Nie można usunąć wydarzenia powiązanego z rezerwacjami.");

            var entity = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;

            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}