using Services.DTO.Room;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRoomEquipmentService
    {
        Task<List<RoomEquipmentItemDto>> GetAllAsync();
        Task<List<RoomEquipmentItemDto>> GetByRoomIdAsync(int roomId);
        Task<RoomEquipmentItemDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateRoomEquipmentDto dto);
        Task<bool> UpdateAsync(UpdateRoomEquipmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}