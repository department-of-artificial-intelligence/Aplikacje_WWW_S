using Services.DTO.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomDTO>> GetAllAsync();
        Task<List<RoomDTO>> GetByBuildingIdAsync(int buildingId);
        Task<List<RoomDTO>> GetActiveRoomsAsync();
        Task<int> CreateAsync(CreateRoomDTO dto);
        Task<bool> UpdateAsync(UpdateRoomDTO dto);
        Task<bool> DeleteAsync(DeleteRoomDTO dto);
    }
}
