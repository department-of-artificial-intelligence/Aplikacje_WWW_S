using Services.ActualServices;
using Services.DTO.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IReservationService
    {
        Task<List<ReservationDTO>> GetAllAsync();
        Task<ReservationDetailsDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateReservationDTO dto);
        Task<bool> UpdateAsync(UpdateReservationDTO dto);
        Task<bool> CancelAsync(int id);
    }
}