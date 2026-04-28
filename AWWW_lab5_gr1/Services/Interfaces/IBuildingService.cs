using System.Collections.Generic;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface IBuildingService
    {
        IEnumerable<BuildingDto> GetAll();
        BuildingDto? GetById(int id);
        void Add(BuildingDto dto);
        void Update(BuildingDto dto);
        void Delete(int id);
    }
}