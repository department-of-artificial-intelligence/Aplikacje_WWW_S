using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using DAL;
using Services.DTO.Building;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Services.ActualServices
{
    public class BuildingService : BaseService, IBuildingService
    {
        public BuildingService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<BuildingDTO>> GetAllAsync()
        {
            return await base._dbContext.Buildings
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new BuildingDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Description = x.Description
                })
                .ToListAsync();
        }

        public async Task<BuildingDTO?> GetByIdAsync(int id)
        {
            return await base._dbContext.Buildings
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new BuildingDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Description = x.Description
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateBuildingDTO dto)
        {
            Building b = new Building();
            b.Name = dto.Name;
            b.Address = dto.Address;
            b.Description = dto.Description;

            base._dbContext.Buildings.Add(b);
            await base._dbContext.SaveChangesAsync();

            return b.Id;
        }

        public async Task<bool> UpdateAsync(UpdateBuildingDTO dto)
        {
            Building? b = await base._dbContext.Buildings.FindAsync(dto.Id);

            if (b == null) return false;

            b.Name = dto.Name;
            b.Address = dto.Address;
            b.Description = dto.Description;

            return await base._dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(DeleteBuildingDTO dto)
        {
            Building? b = await base._dbContext.Buildings.FindAsync(dto.Id);

            if (b == null) return false;

            base._dbContext.Buildings.Remove(b);
            return await base._dbContext.SaveChangesAsync() > 0;
        }
    }
}
