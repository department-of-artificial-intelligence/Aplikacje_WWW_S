using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTO.RoomEquipment;
using Microsoft.EntityFrameworkCore;
using DAL;
using Model;

namespace Services.Services
{
    public class RoomEquipmentService : BaseService, IRoomEquipmentService
    {
        public RoomEquipmentService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<RoomEquipmentItemDto>> GetAllAsync()
        {
            return await _dbContext.RoomsEquipment
                .AsNoTracking()
                .Select(re => MapToDto(re))
                .ToListAsync();
        }

        public async Task<List<RoomEquipmentItemDto>> GetByRoomIdAsync(int roomId)
        {
            return await _dbContext.RoomsEquipment
                .AsNoTracking()
                .Where(re => re.RoomId == roomId)
                .Select(re => MapToDto(re))
                .ToListAsync();
        }

        public async Task<RoomEquipmentItemDto?> GetByIdAsync(int id)
        {
            var entity = await _dbContext.RoomsEquipment
                .AsNoTracking()
                .Include(re => re.Room)
                .Include(re => re.Equipment)
                .FirstOrDefaultAsync(re => re.Id == id);

            return entity != null ? MapToDto(entity) : null;
        }

        public async Task<int> CreateAsync(CreateRoomEquipmentDto dto)
        {
            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Ilość wyposażenia musi być większa od zera.");

            var roomExists = await _dbContext.Rooms.AnyAsync(r => r.Id == dto.RoomId);
            if (!roomExists)
                throw new InvalidOperationException("Wskazana sala nie istnieje.");

            var equipmentExists = await _dbContext.Equipment.AnyAsync(e => e.Id == dto.EquipmentId);
            if (!equipmentExists)
                throw new InvalidOperationException("Wskazany element wyposażenia nie istnieje w słowniku.");

            var alreadyAssigned = await _dbContext.RoomsEquipment
                .AnyAsync(re => re.RoomId == dto.RoomId && re.EquipmentId == dto.EquipmentId);
            if (alreadyAssigned)
                throw new InvalidOperationException("To wyposażenie jest już przypisane do tej sali.");

            var entity = new RoomEquipment
            {
                RoomId = dto.RoomId,
                EquipmentId = dto.EquipmentId,
                Quantity = dto.Quantity
            };

            _dbContext.RoomsEquipment.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomEquipmentDto dto)
        {
            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Ilość wyposażenia musi być większa od zera.");

            var entity = await _dbContext.RoomsEquipment.FindAsync(dto.Id);
            if (entity == null)
                return false;

            entity.Quantity = dto.Quantity;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.RoomsEquipment.FindAsync(id);
            if (entity == null)
                return false;

            _dbContext.RoomsEquipment.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private static RoomEquipmentItemDto MapToDto(RoomEquipment re)
        {
            return new RoomEquipmentItemDto
            {
                Id = re.Id,
                RoomId = re.RoomId,
                RoomName = re.Room?.Name ?? "Brak danych",
                EquipmentId = re.EquipmentId,
                EquipmentName = re.Equipment?.Name ?? "Brak danych",
                Quantity = re.Quantity
            };
        }
    }
}