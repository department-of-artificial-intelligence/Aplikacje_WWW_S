using AutoMapper;
using AutoMapper.QueryableExtensions;  //mapper
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.RoomEquipment;
using Services.Interfaces;

namespace Services.Services
{
    public class RoomEquipmentService : BaseService, IRoomEquipmentService
    {
        public RoomEquipmentService(AppDbContext dbContext, IMapper mapper)
: base(dbContext, mapper) { }

        public async Task<List<RoomEquipmentDto>> GetAllAsync()
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .ProjectTo<RoomEquipmentDto>(_mapper.ConfigurationProvider)  //mapper
                .ToListAsync();
        }
        public async Task<List<RoomEquipmentDto>> GetByRoomIdAsync(int roomId)
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Where(x => x.RoomId == roomId)
                .ProjectTo<RoomEquipmentDto>(_mapper.ConfigurationProvider)  //mapper
                .ToListAsync();
        }

        public async Task<RoomEquipmentDto?> GetByIdAsync(int id)
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<RoomEquipmentDto>(_mapper.ConfigurationProvider)  //mapper
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoomEquipmentDto dto)
        {
            var entity = _mapper.Map<RoomEquipment>(dto);  //mapper

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

            _mapper.Map(dto, entity);  //mapper

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