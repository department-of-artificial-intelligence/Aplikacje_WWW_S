using Services.DTO.RoomEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRoomEquipmentInterface
    {
        Task<IList<RoomEquipmentItemDto>> GetAllAsync();
        Task<IList<RoomEquipmentItemDto>> GetByRoomIdAsync(int roomId);
        Task<RoomEquipmentItemDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateRoomEquipmentDto dto);
        Task<bool> UpdateAsync(UpdateRoomEquipmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
