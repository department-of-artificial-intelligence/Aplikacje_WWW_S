using Kolokwium.Services.DTO.Order;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Meal;
namespace Kolokwium.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>>GetAllAsync();
        Task<OrderDto?>GetByIdAsync(int id);
        Task<int>CreateAsync(CreateOrderDto dto);
        Task<List<MealDto>>GetMealsAsync();
        Task<bool>DeleteAsync (int id);
    }
}