using Kolokwium.Services.DTO.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<RegistrationDto?> GetByIdAsync(int id);

        // Zwraca dokument przypisany do konkretnego auta
        Task<RegistrationDto?> GetByCarIdAsync(int carId);

        // Przypisanie nowego dowodu do auta
        Task<int> CreateAsync(RegistrationDto dto, int carId);

        // Usunięcie/Unieważnienie dokumentu
        Task<bool> DeleteAsync(int id);
    }
}
