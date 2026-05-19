using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.RoomEquipment;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ActualServices {
    internal class RoomEquipmentService : BaseService, IRoomEquipmentService {
        public RoomEquipmentService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<RoomEquipmentDTO>> GetAllAsync() {
            return await base._dbContext.RoomsEquipment
                .AsNoTracking()
                .Select(x => new RoomEquipmentDTO {
                    Id = x.Id,
                    RoomId = x.RoomId,
                    RoomName = x.Room.Name,
                    EquipmentId = x.EquipmentId,
                    EquipmentName = x.Equipment.Name,
                    Quantity = x.Quantity
                })
                .ToListAsync();
        }

        public async Task<List<RoomEquipmentDTO>> GetByRoomIdAsync(int roomId) {
            return await base._dbContext.RoomsEquipment
               .AsNoTracking()
               .Where(x => x.RoomId == roomId)
               .Select(x => new RoomEquipmentDTO {
                   Id = x.Id,
                   RoomId = x.RoomId,
                   RoomName = x.Room.Name,
                   EquipmentId = x.EquipmentId,
                   EquipmentName = x.Equipment.Name,
                   Quantity = x.Quantity
               })
               .ToListAsync();
        }

        public async Task<RoomEquipmentDTO?> GetByIdAsync(int id) {
            return await base._dbContext.RoomsEquipment
               .AsNoTracking()
               .Where(x => x.Id == id)
               .Select(x => new RoomEquipmentDTO {
                   Id = x.Id,
                   RoomId = x.RoomId,
                   RoomName = x.Room.Name,
                   EquipmentId = x.EquipmentId,
                   EquipmentName = x.Equipment.Name,
                   Quantity = x.Quantity
               })
               .FirstOrDefaultAsync();
        }

        public async Task<int> CreateRoomEquipmentAsync(CreateRoomEquipmentDTO dto) {
            try {
                RoomEquipment re = new RoomEquipment();
                re.RoomId = dto.RoomId;

                bool r = await base._dbContext.Rooms.FindAsync(dto.RoomId) == null;

                if (r) { throw new InvalidOperationException("Room does not exist"); }

                re.EquipmentId = dto.EquipmentId;

                bool e = await base._dbContext.Equipment.FindAsync(dto.EquipmentId) == null;

                if (e) { throw new InvalidOperationException("Equipment does not exist"); }

                re.Quantity = dto.Quantity;

                if (dto.Quantity <= 0) { throw new InvalidOperationException("Quantity must be positive"); }

                base._dbContext.RoomsEquipment.Add(re);
                base._dbContext.SaveChanges();
                return re.Id;
            }
            catch (InvalidOperationException ex) { throw new InvalidOperationException(ex.Message); }
        }

        public async Task<bool> UpdateRoomEquipmentAsync(UpdateRoomEquipmentDTO dto) {
            try {
                var re = base._dbContext.RoomsEquipment.Find(dto.Id);

                if (re == null) { return false; }

                re.Quantity = dto.Quantity;

                return await base._dbContext.SaveChangesAsync() > 0;
            } catch (InvalidOperationException ex) { throw new InvalidOperationException(ex.Message); }
        }

        public async Task<bool> DeleteRoomEquipmentAsync(int id) {
            var re = base._dbContext.RoomsEquipment.Find(id);

            if (re == null) { return false; }

            base._dbContext.RoomsEquipment.Remove(re);

            return await base._dbContext.SaveChangesAsync() > 0;
        }
    }
}
