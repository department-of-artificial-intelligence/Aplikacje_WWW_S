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
        Task<List<BuildingDTO>> GetAllAsync();
        Task<BuildingDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateBuildingDTO dto);
        Task<bool> UpdateAsync(UpdateBuildingDTO dto);

        Task<bool> DeleteAsync(DeleteBuildingDTO dto);

    }
}
