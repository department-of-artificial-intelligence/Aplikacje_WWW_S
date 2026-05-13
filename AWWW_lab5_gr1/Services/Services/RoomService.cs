using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        public RoomService(IMapper mapper, AppDbContext dbContext) : base(mapper, dbContext)
        {
        }

        public async Task<IList<RoomDto>> GetAllAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IList<RoomDto>> GetByBuildingIdAsync(int buildingId)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(x => x.BuildingId == buildingId)
                .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IList<RoomDto>> GetActiveRoomsAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(x => x.IsActive)
                .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<RoomDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<RoomDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoomDto dto)
        {
            var entity = _mapper.Map<Room>(dto);

            _dbContext.Rooms.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomDto dto)
        {
            var entity = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity == null) return false;

            _mapper.Map(dto, entity);

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
