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

namespace Services.ActualServices
{
    public class EquipmentService : BaseService, IEquipmentService
    {
        public EquipmentService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<EquipmentDTO>> GetAllAsync()
        {
            return await base._dbContext.Equipment
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(
                    x => new EquipmentDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        IsMobile = x.IsMobile
                    }
                )
                .ToListAsync();
        }

        public async Task<EquipmentDTO?> GetByIdAsync(int id)
        {
            return await base._dbContext.Equipment
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new EquipmentDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsMobile = x.IsMobile
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEquipmentDTO dto)
        {
            Equipment e = new Equipment();
            e.Name = dto.Name;
            e.Description = dto.Description;
            e.IsMobile = dto.IsMobile;

            base._dbContext.Equipment.Add(e);
            await base._dbContext.SaveChangesAsync();

            return e.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEquipmentDTO dto)
        {
            Equipment? e = await base._dbContext.Equipment.FindAsync(dto.Id);

            if (e == null) return false;

            e.Name = dto.Name;
            e.Description = dto.Description;
            e.IsMobile = dto.IsMobile;

            return await base._dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(DeleteEquipmentDTO dto)
        {
            Equipment? e = await base._dbContext.Equipment.FindAsync(dto.Id);

            if (e == null) return false;

            base._dbContext.Equipment.Remove(e);
            return await base._dbContext.SaveChangesAsync() > 0;
        }
    }
}
