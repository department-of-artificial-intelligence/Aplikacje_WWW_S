using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
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
        public EquipmentService(IMapper mapper, AppDbContext dbContext) : base(mapper, dbContext)
        {
        }

        public async Task<IList<EquipmentDto>> GetAllAsync()
        {
            return await _dbContext.Equipments
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<EquipmentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<EquipmentDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Equipments
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<EquipmentDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateEquipmentDto dto)
        {
            var entity = _mapper.Map<Equipment>(dto);

            _dbContext.Equipments.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEquipmentDto dto)
        {
            var entity = await _dbContext.Equipments
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity == null)
                return false;

            _mapper.Map(dto, entity);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Equipments
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _dbContext.Equipments.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
