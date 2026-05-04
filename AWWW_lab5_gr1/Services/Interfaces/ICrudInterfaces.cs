using Services.DTO.EventType;
using Services.DTO.Equipment;

namespace Services.Interfaces
{
    public interface IEventTypeService
    {
        Task<List<EventTypeDto>> GetAllAsync();
        Task<EventTypeDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateEventTypeDto dto);
        Task<bool> UpdateAsync(UpdateEventTypeDto dto);
        Task<bool> DeleteAsync(int id);
    }

    public interface IEquipmentService
    {
        Task<List<EquipmentDto>> GetAllAsync();
        Task<EquipmentDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateEquipmentDto dto);
        Task<bool> UpdateAsync(UpdateEquipmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}