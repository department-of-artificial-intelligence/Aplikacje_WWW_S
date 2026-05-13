using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Model.DataModels;
using Services.DTO.RoomEquipment;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RoomEquipmentService : BaseService, IRoomEquipmentInterface
    {
        public RoomEquipmentService(IMapper mapper, AppDbContext dbContext) : base(mapper, dbContext) { }

        public async Task<IList<RoomEquipmentItemDto>> GetAllAsync()
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .OrderBy(x => x.Room.Building.Name)
                .ThenBy(x => x.Room.Name)
                .ThenBy(x => x.Equipment.Name)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            /*.Select(x => new RoomEquipmentItemDto
            {
                Id = x.Id,
                RoomId = x.RoomId,
                RoomName = x.Room.Name,
                EquipmentId = x.EquipmentId,
                EquipmentName = x.Equipment.Name,
                Quantity = x.Quantity
            }).ToListAsync();*/
        }

        public async Task<IList<RoomEquipmentItemDto>> GetByRoomIdAsync(int roomId)
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Where(x => x.RoomId == roomId)
                .OrderBy(x => x.Equipment.Name)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            /*.Select(x => new RoomEquipmentItemDto
            {
                Id = x.Id,
                RoomId = x.RoomId,
                RoomName = x.Room.Name,
                EquipmentId = x.EquipmentId,
                EquipmentName = x.Equipment.Name,
                Quantity = x.Quantity
            }).ToListAsync();*/
        }

        public async Task<RoomEquipmentItemDto?> GetByIdAsync(int id)
        {
            return await _dbContext.RoomEquipments
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            /*.Select(x => new RoomEquipmentItemDto
            {
                Id = x.Id,
                RoomId = x.RoomId,
                RoomName = x.Room.Name,
                EquipmentId = x.EquipmentId,
                EquipmentName = x.Equipment.Name,
                Quantity = x.Quantity
            }).FirstOrDefaultAsync();*/
        }

        public async Task<int> CreateAsync(CreateRoomEquipmentDto dto)
        {
            //ilość > 0
            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Ilość musi być większa od zera");

            //sala musi istnieć
            if (!await _dbContext.Rooms.AnyAsync(r => r.Id == dto.RoomId))
                throw new InvalidOperationException("Wskazana sala nie istnieje");

            //wyposażenie musi istnieć
            if (!await _dbContext.Equipments.AnyAsync(e => e.Id == dto.EquipmentId))
                throw new InvalidOperationException("Wskazane wyposażenie nie istnieje.");

            //blokada duplikatów
            if (await _dbContext.RoomEquipments.AnyAsync(re => re.RoomId == dto.RoomId && re.EquipmentId == dto.EquipmentId))
                throw new InvalidOperationException("To wyposażenie jest już przypisane do tej sali");

            var entity = _mapper.Map<RoomEquipment>(dto);

            /*var entity = new RoomEquipment
            {
                RoomId = dto.RoomId,
                EquipmentId = dto.EquipmentId,
                Quantity = dto.Quantity
            };*/

            _dbContext.RoomEquipments.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomEquipmentDto dto)
        {
            //ilość > 0 przy edycji
            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Ilość musi być większa od zera");

            var entity = await _dbContext.RoomEquipments.FirstOrDefaultAsync(re => re.Id == dto.Id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);

            //entity.Quantity = dto.Quantity;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.RoomEquipments.FirstOrDefaultAsync(re => re.Id == id);
            if (entity == null) return false;

            _dbContext.RoomEquipments.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}