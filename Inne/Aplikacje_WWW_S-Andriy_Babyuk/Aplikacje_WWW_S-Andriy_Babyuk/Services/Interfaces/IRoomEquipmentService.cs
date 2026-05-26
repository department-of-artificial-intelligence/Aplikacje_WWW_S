using Services.ActualServices;
using Services.DTO.RoomEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces {
   public interface IRoomEquipmentService {
        Task<List<RoomEquipmentDTO>> GetAllAsync();
        Task<List<RoomEquipmentDTO>> GetByRoomIdAsync(int roomId);
        Task<RoomEquipmentDTO?> GetByIdAsync(int id);
        Task<int> CreateRoomEquipmentAsync(CreateRoomEquipmentDTO dto);
        Task<bool> UpdateRoomEquipmentAsync(UpdateRoomEquipmentDTO dto);
        Task<bool> DeleteRoomEquipmentAsync(int roomId);
    }
}
