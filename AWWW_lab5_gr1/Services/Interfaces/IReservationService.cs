using Services.DTO.Reservation;

namespace Services.Interfaces
{
    public interface IReservationService
    {
        Task<List<ReservationListDto>> GetAllAsync();
        Task<ReservationListDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateReservationDto dto);
        Task<bool> UpdateAsync(UpdateReservationDto dto);
        Task<bool> DeleteAsync(int id);
    }
}