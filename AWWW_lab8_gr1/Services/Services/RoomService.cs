using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Room;
using Services.Interfaces;
using AutoMapper.QueryableExtensions; // mapper

namespace Services.Services
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(AppDbContext dbContext, IMapper mapper)
    : base(dbContext, mapper)
        { }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<RoomDto>(_mapper.ConfigurationProvider) //mapper
                .ToListAsync();
        }

        public async Task<List<RoomDto>> GetByBuildingIdAsync(int buildingId)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(x => x.BuildingId == buildingId)
                .OrderBy(x => x.Name)
                .ProjectTo<RoomDto>(_mapper.ConfigurationProvider) //mapper
                .ToListAsync();
        }

        public async Task<List<RoomDto>> GetActiveRoomAsync()
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.Name)
                .ProjectTo<RoomDto>(_mapper.ConfigurationProvider) //mapper
                .ToListAsync();
        }

        public async Task<RoomDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Rooms
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<RoomDetailsDto>(_mapper.ConfigurationProvider) //mapper
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoomDto dto)
        {
            var entity = _mapper.Map<Room>(dto);  //mapper

            _dbContext.Rooms.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomDto dto)
        {
            var entity = await _dbContext.Rooms
        .FirstOrDefaultAsync(x => x.Id == dto.Id);  //mapper

            if (entity == null)
                return false;

            _mapper.Map(dto, entity);  //mapper

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Rooms
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _dbContext.Rooms.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}