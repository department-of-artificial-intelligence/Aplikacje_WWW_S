using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Car;
using Kolokwium.Services.DTO.Registration;
using Kolokwium.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Services
{
    public class RegistartionService : BaseService, IRegistrationService
    {
        public RegistartionService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<RegistrationDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Registrations
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<RegistrationDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<RegistrationDto?> GetByCarIdAsync(int carId)
        {
            return await _dbContext.Registrations
                .AsNoTracking()
                .Where(x => x.CarId == carId) 
                .ProjectTo<RegistrationDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
        public async Task<int> CreateAsync(RegistrationDto dto,int carId)
        {
            var entity = _mapper.Map<Registration>(dto);
            entity.CarId = carId;

            _dbContext.Registrations.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
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
