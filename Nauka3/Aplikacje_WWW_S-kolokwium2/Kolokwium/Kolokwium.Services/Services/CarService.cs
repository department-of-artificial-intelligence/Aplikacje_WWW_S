using AutoMapper;
using Kolokwium.Services.DTO.Car;
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
    public class CarService : BaseService, ICarService
    {
        public CarService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<List<CarDto>> GetAllAsync()
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .OrderBy(x => x.Brand)
                .ProjectTo<CarDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CarDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<CarDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateCarDto dto)
        {
            var entity = _mapper.Map<Car>(dto);

            _dbContext.Cars.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateCarDto dto)
        {
            var entity = await _dbContext.Cars.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Cars.FindAsync(id);
            if (entity == null) return false;

            _dbContext.Cars.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<CarDto>> GetByDriverIdAsync(int driverId)
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .Where(x => x.DriverId == driverId) // Filtrujemy auta po obcym kluczu kierowcy
                .OrderBy(x => x.Brand)
                .ProjectTo<CarDto>(_mapper.ConfigurationProvider) // Mapujemy na lekkie DTO
                .ToListAsync();
        }
    }
}
