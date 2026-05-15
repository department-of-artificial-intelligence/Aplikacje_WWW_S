using DAL;
using Model;
using Services.DTO.EventType;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Services.Services
{
    public class EventTypeService : BaseService, IEventTypeService
    {
        public EventTypeService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<List<EventTypeDto>> GetAllAsync()
        {
            return await _dbContext.EventsType
                .AsNoTracking()
                .ProjectTo<EventTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<EventTypeDto?> GetByIdAsync(int id)
        {
            return await _dbContext.EventsType
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<EventTypeDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventTypeDto dto)
        {
            var entity = _mapper.Map<EventType>(dto);

            _dbContext.EventsType.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEventTypeDto dto)
        {
            var entity = await _dbContext.EventsType.FindAsync(dto.Id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.EventsType.FindAsync(id);
            if (entity == null) return false;

            _dbContext.EventsType.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}