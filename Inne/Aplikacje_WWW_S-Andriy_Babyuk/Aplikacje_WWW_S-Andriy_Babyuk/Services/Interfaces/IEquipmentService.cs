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
        Task<List<EquipmentDTO>> GetAllAsync();
        Task<EquipmentDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateEquipmentDTO dto);
        Task<bool> UpdateAsync(UpdateEquipmentDTO dto);

        Task<bool> DeleteAsync(DeleteEquipmentDTO dto);
    }
}
