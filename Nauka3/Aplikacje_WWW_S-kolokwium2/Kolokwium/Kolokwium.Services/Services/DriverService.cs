using AutoMapper;
using Kolokwium.Services.DTO.Driver;
using Kolokwium.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Services
{
    public class DriverService : BaseService, IDriverService
    {
        public DriverService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<List<DriverDto>> GetAllAsync()
        {
            return await _dbContext.Drivers
                .AsNoTracking()
                .OrderBy(x => x.LastName)
                .ProjectTo<DriverDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<DriverDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Drivers
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<DriverDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateDriverDto dto)
        {
            var entity = _mapper.Map<Driver>(dto);

            _dbContext.Drivers.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateDriverDto dto)
        {
            var entity = await _dbContext.Drivers.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Drivers.FindAsync(id);
            if (entity == null) return false;

            _dbContext.Drivers.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
