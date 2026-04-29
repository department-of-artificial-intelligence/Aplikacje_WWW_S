using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.Room;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<RoomDto>> GetAllAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Select(x => new RoomDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Capacity = x.Capacity,
                    Floor = x.Floor,
                    IsActive = x.IsActive,
                    BuildingId = x.BuildingId,
                    BuildingName = x.Building.Name // Zakładając nawigację do Building
                })
                .ToListAsync();
        }

        public async Task<IList<RoomDto>> GetByBuildingIdAsync(int buildingId)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(x => x.BuildingId == buildingId)
                .Select(x => new RoomDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Capacity = x.Capacity,
                    Floor = x.Floor,
                    IsActive = x.IsActive,
                    BuildingId = x.BuildingId,
                    BuildingName = x.Building.Name
                })
                .ToListAsync();
        }

        public async Task<IList<RoomDto>> GetActiveRoomsAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(x => x.IsActive)
                .Select(x => new RoomDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Capacity = x.Capacity,
                    Floor = x.Floor,
                    IsActive = x.IsActive,
                    BuildingId = x.BuildingId,
                    BuildingName = x.Building.Name
                })
                .ToListAsync();
        }

        public async Task<RoomDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new RoomDetailsDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Capacity = x.Capacity,
                    Floor = x.Floor,
                    IsActive = x.IsActive,
                    BuildingId = x.BuildingId,
                    BuildingName = x.Building.Name,
                    Equipment = x.RoomEquipments.Select(e => new RoomEquipmentItemDto
                    {
                        Id = e.EquipmentId,
                        Name = e.Equipment.Name
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
            var entity = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == dto.Id);

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
            var entity = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return false;

            _dbContext.Rooms.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
