using DAL;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.Equipment;
using Services.Interfaces;

namespace Services.Services
{
    public class EquipmentService : BaseService, IEquipmentService
    {
        public EquipmentService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<EquipmentDto>> GetAllAsync() => await _dbContext.Equipments.AsNoTracking().Select(x => new EquipmentDto { Id = x.Id, Name = x.Name, Description = x.Description, IsMobile = x.IsMobile }).ToListAsync();
        public async Task<EquipmentDto?> GetByIdAsync(int id) => await _dbContext.Equipments.AsNoTracking().Where(x => x.Id == id).Select(x => new EquipmentDto { Id = x.Id, Name = x.Name, Description = x.Description, IsMobile = x.IsMobile }).FirstOrDefaultAsync();

        public async Task<int> CreateAsync(CreateEquipmentDto dto)
        {
            var entity = new Equipment { Name = dto.Name, Description = dto.Description, IsMobile = dto.IsMobile };
            _dbContext.Equipments.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEquipmentDto dto)
        {
            var entity = await _dbContext.Equipments.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;
            entity.Name = dto.Name; entity.Description = dto.Description; entity.IsMobile = dto.IsMobile;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Equipments.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;
            _dbContext.Equipments.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}