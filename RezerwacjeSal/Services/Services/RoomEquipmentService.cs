using AutoMapper.QueryableExtensions;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.Room;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RoomEquipmentService : BaseService, IRoomEquipmentService
    {
        public RoomEquipmentService(AppDbContext dbContext, AutoMapper.IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<RoomEquipmentItemDto>> GetAllAsync()
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<RoomEquipmentItemDto>> GetByRoomIdAsync(int roomId)
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Where(re => re.RoomId == roomId)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<RoomEquipmentItemDto?> GetByIdAsync(int id)
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Where(re => re.Id == id)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoomEquipmentDto dto)
        {
            var roomExists = await _dbContext.Rooms.AnyAsync(r => r.Id == dto.RoomId);
            if (!roomExists)
                throw new InvalidOperationException("Wskazana sala nie istnieje.");

            var equipmentExists = await _dbContext.Equipments.AnyAsync(e => e.Id == dto.EquipmentId);
            if (!equipmentExists)
                throw new InvalidOperationException("Wskazane wyposażenie nie istnieje.");

            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Ilość musi być większa od zera.");

            var isDuplicate = await _dbContext.RoomEquipments
                .AnyAsync(re => re.RoomId == dto.RoomId && re.EquipmentId == dto.EquipmentId);
            if (isDuplicate)
                throw new InvalidOperationException("Ta sala posiada już przypisane to wyposażenie.");

            var entity = _mapper.Map<RoomEquipment>(dto);

            _dbContext.RoomEquipments.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomEquipmentDto dto)
        {
            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Ilość musi być większa od zera.");

            var entity = await _dbContext.RoomEquipments.FirstOrDefaultAsync(re => re.Id == dto.Id);
            if (entity == null)
                return false;

            _mapper.Map(dto, entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.RoomEquipments.FirstOrDefaultAsync(re => re.Id == id);
            if (entity == null)
                return false;

            _dbContext.RoomEquipments.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
