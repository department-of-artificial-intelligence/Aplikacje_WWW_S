using Services.DTO.Reservation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IReservationService
    {
        Task<List<ReservationDto>> GetAllAsync();
        Task<ReservationDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateReservationDto dto);
        Task<bool> UpdateAsync(UpdateReservationDto dto);
        Task<bool> DeleteAsync(int id);
    }
}