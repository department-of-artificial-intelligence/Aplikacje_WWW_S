using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Building;
using Services.DTO.EventType;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ActualServices
{
    public class EventTypeService : BaseService, IEventTypeService
    {
        public EventTypeService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<EventTypeDTO>> GetAllAsync()
        {
            return await base._dbContext.EventTypes
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(
                    x => new EventTypeDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    }
                )
                .ToListAsync();
        }

        public async Task<EventTypeDTO?> GetByIdAsync(int id)
        {
            return await base._dbContext.EventTypes
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new EventTypeDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEventTypeDTO dto)
        {
            EventType e = new EventType();
            e.Name = dto.Name;
            e.Description = dto.Description;

            base._dbContext.EventTypes.Add(e);
            await base._dbContext.SaveChangesAsync();

            return e.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEventTypeDTO dto)
        {
            EventType? e = await base._dbContext.EventTypes.FindAsync(dto.Id);

            if (e == null) return false;

            e.Name = dto.Name;
            e.Description = dto.Description;

            return await base._dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(DeleteEventTypeDTO dto)
        {
            EventType? e = await base._dbContext.EventTypes.FindAsync(dto.Id);

            if (e == null) return false;

            base._dbContext.EventTypes.Remove(e);
            return await base._dbContext.SaveChangesAsync() > 0;
        }
    }
}
