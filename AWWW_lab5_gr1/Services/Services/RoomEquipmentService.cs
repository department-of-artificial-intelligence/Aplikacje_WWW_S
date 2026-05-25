using DAL;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.RoomEquipment;
using Services.Interfaces;

namespace Services.Services
{
    public class RoomEquipmentService : BaseService, IRoomEquipmentService
    {
        public RoomEquipmentService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<List<RoomEquipmentItemDto>> GetAllAsync()
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .OrderBy(x => x.Room.Building.Name)
                .ThenBy(x => x.Room.Name)
                .ThenBy(x => x.Equipment.Name)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<RoomEquipmentItemDto>> GetByRoomIdAsync(int roomId)
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Where(x => x.RoomId == roomId)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<RoomEquipmentItemDto?> GetByIdAsync(int id)
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoomEquipmentDto dto)
        {
            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Ilość musi być większa od zera.");

            if (!await _dbContext.Rooms.AnyAsync(r => r.Id == dto.RoomId))
                throw new InvalidOperationException("Wskazana sala nie istnieje.");

            if (!await _dbContext.Equipments.AnyAsync(e => e.Id == dto.EquipmentId))
                throw new InvalidOperationException("Wskazane wyposażenie nie istnieje.");

            if (await _dbContext.RoomEquipments.AnyAsync(re => re.RoomId == dto.RoomId && re.EquipmentId == dto.EquipmentId))
                throw new InvalidOperationException("To wyposażenie jest już przypisane do tej sali.");

            var entity = _mapper.Map<RoomEquipment>(dto);
            _dbContext.RoomEquipments.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomEquipmentDto dto)
        {
            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Ilość musi być większa od zera.");

            var entity = await _dbContext.RoomEquipments.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.RoomEquipments.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;

            _dbContext.RoomEquipments.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}