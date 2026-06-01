using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.EventType;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions; // mapper

namespace Services.Services
{
    public class EventTypeService : BaseService, IEventTypeService
    {
        public EventTypeService(AppDbContext dbContext, IMapper mapper)
    : base(dbContext, mapper) { }

        public async Task<List<EventDto>> GetAllAsync()
        {
            return await _dbContext.EventTypes
                .AsNoTracking()
                .Select(x => new EventDto
                {
                    Id = x.Id,
                    Name = x.Name!,
                    Description = x.Description
                })
                .ToListAsync();
        }

        public async Task<EventDto?> GetByIdAsync(int id)
        {
            return await _dbContext.EventTypes
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<EventDto>(_mapper.ConfigurationProvider)  //mapper
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventTypeDto dto)
        {
            var entity = _mapper.Map<EventType>(dto);  //mapper

            _dbContext.EventTypes.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEventTypeDto dto)
        {
            var entity = await _dbContext.EventTypes.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity == null)
                return false;

            _mapper.Map(dto, entity);  //mapper

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.EventTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _dbContext.EventTypes.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
