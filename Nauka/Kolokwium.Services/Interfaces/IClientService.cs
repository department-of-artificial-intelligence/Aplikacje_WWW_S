using Kolokwium.Services.DTO.Order;
using Kolokwium.Services.DTO.Client;

namespace Kolokwium.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAllAsync();
        Task<ClientDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateClientDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<OrderDto>> GetOrdersAsync();
    }
}