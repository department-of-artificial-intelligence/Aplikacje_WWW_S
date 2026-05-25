using System.Collections.Generic;
using System.Threading.Tasks;
using Kolokwium.Services.DTO.Product;

namespace Kolokwium.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateProductDto dto);
        Task<bool> UpdateAsync(UpdateProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}