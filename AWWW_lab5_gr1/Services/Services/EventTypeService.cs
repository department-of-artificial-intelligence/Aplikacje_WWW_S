using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.EventType;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EventTypeService : BaseService, IEventTypeService
    {
        public EventTypeService(IMapper mapper, AppDbContext dbContext) : base(mapper, dbContext)
        {
        }

        public async Task<IList<EventTypeDto>> GetAllAsync()
        {
            return await _dbContext.EventTypes
                .AsNoTracking()
                .OrderBy(x => x.Name)
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
            var entity = await _dbContext.EventTypes
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity == null)
                return false;

            _mapper.Map(dto, entity);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.EventTypes
                .Include(et => et.Events)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            if (entity.Events.Any())
                throw new InvalidOperationException("Nie można usunąć typu wydarzenia, do którego przypisane są wydarzenia.");

            _dbContext.EventTypes.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
