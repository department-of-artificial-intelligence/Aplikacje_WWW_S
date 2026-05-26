using DAL;
using Microsoft.EntityFrameworkCore;
using Services.DTO.Building;
using Services.Interfaces;
using AutoMapper.QueryableExtensions;

namespace Services.Services
{
    public class BuildingService : BaseService, IBuildingService
    {
        public BuildingService(AppDbContext dbContext, AutoMapper.IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<BuildingDto>> GetAllAsync()
        {
            return await _dbContext.Buildings
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<BuildingDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<BuildingDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Buildings
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<BuildingDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateBuildingDto dto)
        {
            var entity = _mapper.Map<Model.DataModels.Building>(dto);

            _dbContext.Buildings.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateBuildingDto dto)
        {
            var entity = await _dbContext.Buildings.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
                return false;

            _mapper.Map(dto, entity);

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

