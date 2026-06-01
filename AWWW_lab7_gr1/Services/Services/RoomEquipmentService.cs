using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.RoomEquipment;
using Services.Interfaces;

namespace Services.Services
{
    public class RoomEquipmentService : BaseService, IRoomEquipmentService
    {
        public RoomEquipmentService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<RoomEquipmentDto>> GetAllAsync()
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Select(x => new RoomEquipmentDto
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    RoomId = x.RoomId,
                    RoomName = x.Room!.Name!,
                    EquipmentId = x.EquipmentId,
                    EquipmentName = x.Equipment!.Name!
                })
                .ToListAsync();
        }
        public async Task<List<RoomEquipmentDto>> GetByRoomIdAsync(int roomId)
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Where(x => x.RoomId == roomId)
                .Select(x => new RoomEquipmentDto
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    RoomId = x.RoomId,
                    RoomName = x.Room!.Name!,
                    EquipmentId = x.EquipmentId,
                    EquipmentName = x.Equipment!.Name!
                })
                .ToListAsync();
        }

        public async Task<RoomEquipmentDto?> GetByIdAsync(int id)
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new RoomEquipmentDto
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    RoomId = x.RoomId,
                    RoomName = x.Room!.Name!,
                    EquipmentId = x.EquipmentId,
                    EquipmentName = x.Equipment!.Name!
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoomEquipmentDto dto)
        {
            var entity = new RoomEquipment
            {
                RoomId = dto.RoomId,
                EquipmentId = dto.EquipmentId,
                Quantity = dto.Quantity
            };

            _dbContext.RoomEquipments.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomEquipmentDto dto)
        {
            var entity = await _dbContext.RoomEquipments
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity == null)
                return false;

            entity.RoomId = dto.RoomId;
            entity.EquipmentId = dto.EquipmentId;
            entity.Quantity = dto.Quantity;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.RoomEquipments
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _dbContext.RoomEquipments.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}