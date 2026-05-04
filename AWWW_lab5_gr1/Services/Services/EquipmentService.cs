using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Equipment;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EquipmentService : BaseService, IEquipmentService
    {
        public EquipmentService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<EquipmentDto>> GetAllAsync()
        {
            return await _dbContext.Equipment
                .AsNoTracking()
                .Select(x => new EquipmentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsMobile = x.IsMobile
                })
                .ToListAsync();
        }

        public async Task<EquipmentDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Equipment
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new EquipmentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsMobile = x.IsMobile
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEquipmentDto dto)
        {
            var entity = new Equipment
            {
                Name = dto.Name,
                Description = dto.Description,
                IsMobile = dto.IsMobile
            };

            _dbContext.Equipment.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEquipmentDto dto)
        {
            var entity = await _dbContext.Equipment.FindAsync(dto.Id);
            if (entity == null) return false;

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.IsMobile = dto.IsMobile;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Equipment.FindAsync(id);
            if (entity == null) return false;

            _dbContext.Equipment.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}