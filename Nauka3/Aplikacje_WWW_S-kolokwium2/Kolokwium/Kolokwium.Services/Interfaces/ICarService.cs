using Kolokwium.Services.DTO.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Interfaces
{
    public interface ICarService
    {
        Task<List<CarDto>> GetAllAsync();

        // Zwraca CarDetailsDto zawierający spłaszczone dane kierowcy i dowodu
        Task<CarDetailsDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateCarDto dto);

        Task<bool> UpdateAsync(UpdateCarDto dto);

        Task<bool> DeleteAsync(int id);

        // Dodatkowa metoda biznesowa: pobranie aut tylko jednego kierowcy
        Task<List<CarDto>> GetByDriverIdAsync(int driverId);
    }
}
