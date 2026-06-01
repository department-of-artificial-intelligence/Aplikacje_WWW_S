using Services.DTO.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBuildingService
    {
        Task<List<BuildingDto>> GetAllAsync();
        Task<BuildingDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateBuildingDto dto);
        Task<bool> UpdateAsync(UpdateBuildingDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
