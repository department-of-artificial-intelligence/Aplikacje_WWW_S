using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Room;
using Services.Interfaces;
using Services.DTO.RoomEquipment;

namespace Services.Services
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Include(r => r.Building)
                .Select(r => new RoomDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Capacity = r.Capacity,
                    Floor = r.Floor,
                    IsActive = r.IsActive,
                    BuildingId = r.BuildingId,
                    BuildingName = r.Building.Name
                })
                .ToListAsync();
        }

        public async Task<List<RoomDto>> GetByBuildingIdAsync(int buildingId)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Include(r => r.Building)
                .Where(r => r.BuildingId == buildingId)
                .Select(r => new RoomDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Capacity = r.Capacity,
                    Floor = r.Floor,
                    IsActive = r.IsActive,
                    BuildingId = r.BuildingId,
                    BuildingName = r.Building.Name
                })
                .ToListAsync();
        }

        public async Task<List<RoomDto>> GetActiveRoomsAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Include(r => r.Building)
                .Where(r => r.IsActive)
                .Select(r => new RoomDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Capacity = r.Capacity,
                    Floor = r.Floor,
                    IsActive = r.IsActive,
                    BuildingId = r.BuildingId,
                    BuildingName = r.Building.Name
                })
                .ToListAsync();
        }

        public async Task<RoomDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Include(r => r.Building)
                .Include(r => r.RoomEquipments)
                    .ThenInclude(re => re.Equipment)
                .Where(r => r.Id == id)
                .Select(r => new RoomDetailsDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Capacity = r.Capacity,
                    Floor = r.Floor,
                    IsActive = r.IsActive,
                    BuildingId = r.BuildingId,
                    BuildingName = r.Building.Name,
                    Equipment = r.RoomEquipments.Select(re => new RoomEquipmentItemDto
                    {
                        Id = re.EquipmentId,
                        Name = re.Equipment.Name,
                        Quantity = re.Quantity
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoomDto dto)
        {
            var entity = new Room
            {
                Name = dto.Name,
                Capacity = dto.Capacity,
                Floor = dto.Floor,
                IsActive = dto.IsActive,
                BuildingId = dto.BuildingId
            };

            _dbContext.Rooms.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomDto dto)
        {
            var entity = await _dbContext.Rooms.FindAsync(dto.Id);
            if (entity == null) return false;

            entity.Name = dto.Name;
            entity.Capacity = dto.Capacity;
            entity.Floor = dto.Floor;
            entity.IsActive = dto.IsActive;
            entity.BuildingId = dto.BuildingId;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Rooms.FindAsync(id);
            if (entity == null) return false;

            _dbContext.Rooms.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
