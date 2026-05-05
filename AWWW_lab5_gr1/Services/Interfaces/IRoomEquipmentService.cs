using Services.DTO.RoomEquipment;

namespace Services.Interfaces
{
    public interface IRoomEquipmentService
    {
        Task<List<RoomEquipmentItemDto>> GetAllSync();

        Task<List<RoomEquipmentItemDto>> GetByRoomId(int roomId);

        Task<RoomEquipmentItemDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateRoomEquipmentDto dto);

        Task<bool> UpdateAsync(UpdateRoomEquipmentDto dto);

        Task<bool> DeleteAsync(int id);
    }
}