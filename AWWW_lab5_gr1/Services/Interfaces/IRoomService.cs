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
        Task<IList<RoomDto>> GetAllAsync();
        Task<IList<RoomDto>> GetByBuildingIdAsync(int buildingId);
        Task<IList<RoomDto>> GetActiveRoomsAsync();
        Task<RoomDetailsDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateRoomDto dto);
        Task<bool> UpdateAsync(UpdateRoomDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
