using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTO.Building;

namespace Services.Interfaces
{
    public interface IBuildingService
    {
        Task<List<BuildingDto>> GetAllAsync();
        Task<int> CreateAsync(CreateBuildingDto dto);
        Task<bool> UpdateAsync(BuildingDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
