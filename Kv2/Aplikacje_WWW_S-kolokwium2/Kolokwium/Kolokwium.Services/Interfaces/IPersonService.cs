using Kolokwium.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto?> GetByIdAsync(int id);
        Task CreateAsync(CreatePersonDto dto); // Zmiana typu
        Task UpdateAsync(UpdatePersonDto dto); // Zmiana typu
        Task DeleteAsync(int id);
    }
}
