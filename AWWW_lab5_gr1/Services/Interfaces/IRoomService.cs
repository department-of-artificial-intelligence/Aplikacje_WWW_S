using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTO.Room;

namespace Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllAsync();
        Task<List<RoomDto>> GetByBuildingIdAsync(int buildingId);
        Task<List<RoomDto>> GetActiveRoomsAsync();
        Task<RoomDetailsDto?> GetByIdAsync(int id);
        Task<int>CreateAsync(CreateRoomDto dto);
        Task<bool>UpdateAsync(UpdateRoomDto dto);
        Task<bool> DeleteAsync(int id);
    }
}