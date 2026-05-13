using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.Building;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BuildingService : BaseService, IBuildingService
    {
        public BuildingService(IMapper mapper, AppDbContext dbContext) : base(mapper, dbContext)
        {
        }

        public async Task<IList<BuildingDto>> GetAllAsync()
        {
            return await _dbContext.Buildings
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<BuildingDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            /*.Select(x => new BuildingDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Description = x.Description
            })
            .ToListAsync();*/
        }

        public async Task<BuildingDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Buildings
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<BuildingDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
                /*.Select(x => new BuildingDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Description = x.Description
                })
                .FirstOrDefaultAsync();*/
        }

        public async Task<int> CreateAsync(CreateBuildingDto dto)
        {
            var entity = _mapper.Map<Building>(dto);
            /*var entity = new Building
            {
                Name = dto.Name,
                Address = dto.Address,
                Description = dto.Description
            };*/

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

            /*entity.Name = dto.Name;
            entity.Address = dto.Address;
            entity.Description = dto.Description;*/

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Buildings
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _dbContext.Buildings.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
