using AutoMapper;
using AutoMapper.QueryableExtensions;  //mapper
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Building;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BuildingService : BaseService, IBuildingService
    {
        public BuildingService(AppDbContext dbContext, IMapper mapper)
    : base(dbContext, mapper)
        { }

        public async Task<List<BuildingDto>> GetAllAsync()
        {
            return await _dbContext.Buildings
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<BuildingDto>(_mapper.ConfigurationProvider)  //mapper
                .ToListAsync();
        }

        public async Task<BuildingDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Buildings
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<BuildingDto>(_mapper.ConfigurationProvider)  //mapper
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateBuildingDto dto)
        {
            var entity = _mapper.Map<Building>(dto);  //mapper

            _dbContext.Buildings.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateBuildingDto dto)
        {
            var entity = await _dbContext.Buildings.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity == null)
                return false;

            _mapper.Map(dto, entity);  //mapper

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Buildings.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _dbContext.Buildings.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }

}
