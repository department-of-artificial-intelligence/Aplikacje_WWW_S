using Services.DTO.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEquipmentService
    {
        Task<List<EquipmentDto>> GetAllAsync();
        Task<EquipmentDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateEquipmentDto dto);
        Task<bool> UpdateAsync(UpdateEquipmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
