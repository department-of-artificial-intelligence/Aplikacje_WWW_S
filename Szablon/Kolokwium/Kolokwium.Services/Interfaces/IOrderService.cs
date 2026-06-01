using Kolokwium.Services.DTO;
using Kolokwium.Model.DataModels;

namespace Kolokwium.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();

        Task<OrderDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateOrderDto dto);
        
        Task<bool> DeleteAsync (int id);

        Task<List<MealDto>> GetMealsAsync();

    }
}