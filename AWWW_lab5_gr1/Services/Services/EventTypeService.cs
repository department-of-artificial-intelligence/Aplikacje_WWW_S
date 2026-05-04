using DAL;
using Model;
using Services.DTO.EventType;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class EventTypeService : BaseService, IEventTypeService
    {
        public EventTypeService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<EventTypeDto>> GetAllAsync()
        {
            return await _dbContext.EventsType
                .AsNoTracking()
                .Select(x => new EventTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description 
                })
                .ToListAsync();
        }

        public async Task<EventTypeDto?> GetByIdAsync(int id)
        {
            return await _dbContext.EventsType
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new EventTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description 
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventTypeDto dto)
        {
            var entity = new EventType
            {
                Name = dto.Name,
                Description = dto.Description 
            };

            _dbContext.EventsType.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEventTypeDto dto)
        {
            var entity = await _dbContext.EventsType.FindAsync(dto.Id);
            if (entity == null) return false;

            entity.Name = dto.Name;
            entity.Description = dto.Description; 

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