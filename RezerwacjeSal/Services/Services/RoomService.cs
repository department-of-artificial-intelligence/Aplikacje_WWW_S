using AutoMapper.QueryableExtensions;
using DAL;
using Microsoft.EntityFrameworkCore;
using Services.DTO.Room;
using Services.Interfaces;

namespace Services.Services
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(AppDbContext dbContext, AutoMapper.IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .OrderBy(r => r.Name)
                .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<RoomDto>> GetByBuildingIdAsync(int buildingId)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(r => r.BuildingId == buildingId)
                .OrderBy(r => r.Name)
                .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<RoomDto>> GetActiveRoomsAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(r => r.IsActive)
                .OrderBy(r => r.Name)
                .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<RoomDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(r => r.Id == id)
                .ProjectTo<RoomDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoomDto dto)
        {
            var entity = _mapper.Map<Model.DataModels.Room>(dto);

            _dbContext.Rooms.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomDto dto)
        {
            var entity = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
                return false;

            _mapper.Map(dto, entity);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return false;

            _dbContext.Rooms.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

