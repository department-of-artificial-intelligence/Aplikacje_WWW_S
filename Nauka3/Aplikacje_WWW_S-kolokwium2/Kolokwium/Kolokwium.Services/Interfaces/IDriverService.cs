using Kolokwium.Services.DTO.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Interfaces
{
    public interface IDriverService
    {
        // Pobranie wszystkich (lekki DriverDto pod Index)
        Task<List<DriverDto>> GetAllAsync();

        // Pobranie jednego ze szczegółami i listą aut (DriverDetailsDto pod Details)
        Task<DriverDetailsDto?> GetByIdAsync(int id);

        // Tworzenie (przyjmuje CreateDriverDto bez Id, zwraca Id nowego rekordu)
        Task<int> CreateAsync(CreateDriverDto dto);

        // Aktualizacja (przyjmuje UpdateDriverDto z Id, zwraca bool czy się udało)
        Task<bool> UpdateAsync(UpdateDriverDto dto);

        // Usuwanie (zwraca bool czy rekord istniał i został usunięty)
        Task<bool> DeleteAsync(int id);
    }
}
