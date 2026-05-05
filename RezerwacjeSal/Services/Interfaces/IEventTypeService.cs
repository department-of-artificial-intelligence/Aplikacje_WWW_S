using Services.DTO.EventType;

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
}
