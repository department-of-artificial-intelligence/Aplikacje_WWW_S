using Services.DTO.Reservation;
using Services.DTO.RoomEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    internal interface IReservationService
    {
        Task<List<ReservationDto>> GetAllAsync();
        Task<List<ReservationDto>> GetByRoomIdAsync(int roomId);
        Task<List<ReservationDto>> GetByEventIdAsync(int eventId);
        Task<ReservationDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateReservationDto dto);
        Task<bool> UpdateAsync(UpdateReservationDto dto);
        Task<bool> DeleteAsync(int id);
    }
}