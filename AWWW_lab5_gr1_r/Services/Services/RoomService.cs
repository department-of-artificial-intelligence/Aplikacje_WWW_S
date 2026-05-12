using DAL;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Services.DTO.Room;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            return await _dbContext.Rooms
                .Include(x => x.Building)
                .AsNoTracking()
                .Select(x => new RoomDto
                {
                    Id = x.Id, Name = x.Name, Capacity = x.Capacity, Floor = x.Floor,
                    IsActive = x.IsActive, BuildingId = x.BuildingId, BuildingName = x.Building.Name
                }).ToListAsync();
        }

        public async Task<List<RoomDto>> GetByBuildingIdAsync(int buildingId)
        {
            return await _dbContext.Rooms
                .Include(x => x.Building)
                .Where(x => x.BuildingId == buildingId)
                .AsNoTracking()
                .Select(x => new RoomDto
                {
                    Id = x.Id, Name = x.Name, Capacity = x.Capacity, Floor = x.Floor,
                    IsActive = x.IsActive, BuildingId = x.BuildingId, BuildingName = x.Building.Name
                }).ToListAsync();
        }

        public async Task<List<RoomDto>> GetActiveRoomsAsync()
        {
            return await _dbContext.Rooms
                .Include(x => x.Building)
                .Where(x => x.IsActive)
                .AsNoTracking()
                .Select(x => new RoomDto
                {
                    Id = x.Id, Name = x.Name, Capacity = x.Capacity, Floor = x.Floor,
                    IsActive = x.IsActive, BuildingId = x.BuildingId, BuildingName = x.Building.Name
                }).ToListAsync();
        }

        public async Task<RoomDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Rooms
                .Include(x => x.Building)
                .Include(x => x.RoomEquipments).ThenInclude(re => re.Equipment)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(x => new RoomDetailsDto
                {
                    Id = x.Id, Name = x.Name, Capacity = x.Capacity, Floor = x.Floor,
                    IsActive = x.IsActive, BuildingId = x.BuildingId, BuildingName = x.Building.Name,
                    Equipment = x.RoomEquipments.Select(re => new RoomEquipmentItemDto 
                    { 
                        Id = re.EquipmentId, Name = re.Equipment.Name, Quantity = re.Quantity 
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoomDto dto)
        {
            var entity = new Room
            {
                Name = dto.Name, Capacity = dto.Capacity, Floor = dto.Floor,
                IsActive = dto.IsActive, BuildingId = dto.BuildingId
            };
            _dbContext.Rooms.Add(entity); await _dbContext.SaveChangesAsync(); return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomDto dto)
        {
            var entity = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;
            entity.Name = dto.Name; entity.Capacity = dto.Capacity; entity.Floor = dto.Floor;
            entity.IsActive = dto.IsActive; entity.BuildingId = dto.BuildingId;
            await _dbContext.SaveChangesAsync(); return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;
            _dbContext.Rooms.Remove(entity); await _dbContext.SaveChangesAsync(); return true;
        }
    }
}