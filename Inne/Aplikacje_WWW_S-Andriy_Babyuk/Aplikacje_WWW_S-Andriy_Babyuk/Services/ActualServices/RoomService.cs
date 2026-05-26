using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Room;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ActualServices
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<RoomDTO>> GetAllAsync()
        {
            return await base._dbContext.Rooms
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new RoomDTO
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

        public async Task<List<RoomDTO>> GetByBuildingIdAsync(int buildingId)
        {
            return await base._dbContext.Rooms
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Where(x => x.BuildingId == buildingId)
                .Select(x => new RoomDTO
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

        public async Task<List<RoomDTO>> GetActiveRoomsAsync()
        {
            return await base._dbContext.Rooms
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Where(x => x.IsActive)
                .Select(x => new RoomDTO
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

        public async Task<int> CreateAsync(CreateRoomDTO dto)
        {
            Room r = new Room();
            r.Name = dto.Name;
            r.Capacity = dto.Capacity;
            r.Floor = dto.Floor;
            r.IsActive = dto.IsActive;
            r.BuildingId = dto.BuildingId;

            base._dbContext.Rooms.Add(r);
            await base._dbContext.SaveChangesAsync();

            return r.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomDTO dto)
        {
            Room? r = await base._dbContext.Rooms.FindAsync(dto.Id);

            if (r == null) return false;

            r.Id = dto.Id;
            r.Name = dto.Name;
            r.Capacity = dto.Capacity;
            r.Floor = dto.Floor;
            r.IsActive = dto.IsActive;
            r.BuildingId = dto.BuildingId;

            return await base._dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(DeleteRoomDTO dto)
        {
            Room? r = await base._dbContext.Rooms.FindAsync(dto.Id);

            if (r == null) return false;

            base._dbContext.Rooms.Remove(r);
            return await base._dbContext.SaveChangesAsync() > 0;
        }
    }
}
