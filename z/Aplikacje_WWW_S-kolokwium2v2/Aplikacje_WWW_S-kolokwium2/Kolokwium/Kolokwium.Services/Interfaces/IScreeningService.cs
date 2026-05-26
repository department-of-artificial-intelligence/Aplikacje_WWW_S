using Kolokwium.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IScreeningService
    {
        Task<IEnumerable<ScreeningDto>> GetAllAsync();
        Task<ScreeningDto> GetByIdAsync(int id);
        Task CreateAsync(ScreeningDto dto);
    }
}