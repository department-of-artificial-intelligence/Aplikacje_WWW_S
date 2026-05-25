using DAL;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.EventType;
using Services.Interfaces;

namespace Services.Services
{
    public class EventTypeService : BaseService, IEventTypeService
    {
        public EventTypeService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<List<EventTypeDto>> GetAllAsync()
        {
            return await _dbContext.EventTypes
                .AsNoTracking()
                .ProjectTo<EventTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<EventTypeDto?> GetByIdAsync(int id)
        {
            return await _dbContext.EventTypes
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<EventTypeDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventTypeDto dto)
        {
            var entity = _mapper.Map<EventType>(dto);
            _dbContext.EventTypes.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEventTypeDto dto)
        {
            var entity = await _dbContext.EventTypes.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.EventTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;

            _dbContext.EventTypes.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}