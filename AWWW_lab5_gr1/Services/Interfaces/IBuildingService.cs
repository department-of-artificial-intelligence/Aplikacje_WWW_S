using Services.DTO.Building;

namespace Services.Interfaces
{
    public interface IBuildingService
    {
        Task<List<BuildingDto>> GetAllAsync();
        Task<BuildingDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateBuildingDto dto);
        Task<bool> UpdateAsync(BuildingDto dto);
        Task<bool> DeleteAsync(int id);
    }
}