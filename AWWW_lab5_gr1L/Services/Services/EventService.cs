using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Event;
using Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EventService : BaseService, IEventService
    {
        public EventService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<List<EventDto>> GetAllAsync()
        {
            return await _dbContext.Events
                .AsNoTracking()
                .OrderByDescending(e => e.CreatedAt)
                .ThenBy(e => e.Title)
                .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<EventDto>> GetPublicEventsAsync()
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Where(e => e.IsPublic)
                .OrderByDescending(e => e.CreatedAt)
                .ThenBy(e => e.Title)
                .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<EventDto>> GetByEventTypeIdAsync(int eventTypeId)
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Where(e => e.EventTypeId == eventTypeId)
                .OrderByDescending(e => e.CreatedAt)
                .ThenBy(e => e.Title)
                .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<EventDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Events
                .AsNoTracking()
                .Where(e => e.Id == id)
                .ProjectTo<EventDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventDto dto)
        {
            if (dto.ParticipantsLimit <= 0)
                throw new InvalidOperationException("Liczba uczestników musi być większa od 0.");

            var typeExists = await _dbContext.EventsType.AnyAsync(t => t.Id == dto.EventTypeId);
            if (!typeExists)
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

            var entity = await _dbContext.Events.FindAsync(dto.Id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);

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
    }
}