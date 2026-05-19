using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
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
                .Include(x => x.Room)
                .Include(x => x.Equipment)
                .AsNoTracking()
                .Select(x => new RoomEquipmentItemDto
                {
                    Id = x.Id,
                    RoomId = x.RoomId,
                    RoomName = x.Room.Name,
                    EquipmentId = x.EquipmentId,
                    EquipmentName = x.Equipment.Name,
                    Quantity = x.Quantity
                }).ToListAsync();
        }

        public async Task<List<RoomEquipmentItemDto>> GetByRoomIdAsync(int roomId)
        {
            return await _dbContext.RoomEquipments
                .Include(x => x.Room)
                .Include(x => x.Equipment)
                .Where(x => x.RoomId == roomId)
                .AsNoTracking()
                .Select(x => new RoomEquipmentItemDto
                {
                    Id = x.Id,
                    RoomId = x.RoomId,
                    RoomName = x.Room.Name,
                    EquipmentId = x.EquipmentId,
                    EquipmentName = x.Equipment.Name,
                    Quantity = x.Quantity
                }).ToListAsync();
        }

        public async Task<RoomEquipmentItemDto?> GetByIdAsync(int id)
        {
            return await _dbContext.RoomEquipments
                .Include(x => x.Room)
                .Include(x => x.Equipment)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(x => new RoomEquipmentItemDto
                {
                    Id = x.Id,
                    RoomId = x.RoomId,
                    RoomName = x.Room.Name,
                    EquipmentId = x.EquipmentId,
                    EquipmentName = x.Equipment.Name,
                    Quantity = x.Quantity
                }).FirstOrDefaultAsync();
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
                throw new InvalidOperationException("Ta sala ma już przypisany ten element wyposażenia.");

            var entity = new RoomEquipment
            {
                RoomId = dto.RoomId,
                EquipmentId = dto.EquipmentId,
                Quantity = dto.Quantity
            };

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

            entity.Quantity = dto.Quantity;
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