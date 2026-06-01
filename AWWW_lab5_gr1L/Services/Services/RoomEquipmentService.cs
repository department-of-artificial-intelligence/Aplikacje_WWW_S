using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTO.RoomEquipment;
using Microsoft.EntityFrameworkCore;
using DAL;
using Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Services.Services
{
    public class RoomEquipmentService : BaseService, IRoomEquipmentService
    {
        public RoomEquipmentService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<List<RoomEquipmentItemDto>> GetAllAsync()
        {
            return await _dbContext.RoomsEquipment
                .AsNoTracking()
                .OrderBy(x => x.Room.Building.Name)
                .ThenBy(x => x.Room.Name)
                .ThenBy(x => x.Equipment.Name)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<RoomEquipmentItemDto>> GetByRoomIdAsync(int roomId)
        {
            return await _dbContext.RoomsEquipment
                .AsNoTracking()
                .Where(re => re.RoomId == roomId)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<RoomEquipmentItemDto?> GetByIdAsync(int id)
        {
            return await _dbContext.RoomsEquipment
                .AsNoTracking()
                .Where(re => re.Id == id)
                .ProjectTo<RoomEquipmentItemDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoomEquipmentDto dto)
        {
            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Ilość wyposażenia musi być większa od zera.");

            var roomExists = await _dbContext.Rooms.AnyAsync(r => r.Id == dto.RoomId);
            if (!roomExists)
                throw new InvalidOperationException("Wskazana sala nie istnieje.");

            var equipmentExists = await _dbContext.Equipment.AnyAsync(e => e.Id == dto.EquipmentId);
            if (!equipmentExists)
                throw new InvalidOperationException("Wskazany element wyposażenia nie istnieje w słowniku.");

            var alreadyAssigned = await _dbContext.RoomsEquipment
                .AnyAsync(re => re.RoomId == dto.RoomId && re.EquipmentId == dto.EquipmentId);
            if (alreadyAssigned)
                throw new InvalidOperationException("To wyposażenie jest już przypisane do tej sali.");

            var entity = _mapper.Map<RoomEquipment>(dto);

            _dbContext.RoomsEquipment.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateRoomEquipmentDto dto)
        {
            var entity = await _dbContext.RoomsEquipment
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity == null)
                return false;

            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Ilość wyposażenia musi być większa od zera.");

            _mapper.Map(dto, entity);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.RoomsEquipment.FindAsync(id);
            if (entity == null)
                return false;

            _dbContext.RoomsEquipment.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateQuantityAsync(int roomId, int equipmentId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException("Ilość musi być większa od zera.");
            }

            var roomEquipment = await _dbContext.RoomsEquipment
                .FirstOrDefaultAsync(x => x.RoomId == roomId && x.EquipmentId == equipmentId);

            if (roomEquipment == null)
            {
                throw new InvalidOperationException("Nie odnaleziono powiązania wyposażenia z tą salą.");
            }

            roomEquipment.Quantity = quantity;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int roomId, int equipmentId)
        {
            var roomEquipment = await _dbContext.RoomsEquipment
                .FirstOrDefaultAsync(x => x.RoomId == roomId && x.EquipmentId == equipmentId);

            if (roomEquipment == null)
            {
                throw new InvalidOperationException("Nie odnaleziono przypisania tego wyposażenia do sali.");
            }


            _dbContext.RoomsEquipment.Remove(roomEquipment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AssignAsync(IEnumerable<CreateRoomEquipmentDto> dtos)
        {
            var items = dtos.ToList();
            if (!items.Any())
            {
                throw new InvalidOperationException("Wybierz co najmniej jedno wyposażenie.");
            }

            if (_dbContext.Database.IsRelational())
            {
                await using var transaction = await _dbContext.Database.BeginTransactionAsync();
                try
                {
                    foreach (var dto in items)
                    {
                        await CreateAsync(dto);
                    }
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                return;
            }

            foreach (var dto in items)
            {
                await CreateAsync(dto);
            }
        }
    }
}
