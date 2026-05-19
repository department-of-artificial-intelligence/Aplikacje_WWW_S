using Services.DTO.Event;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEventService
    {
        Task<List<EventDto>> GetAllAsync();
        Task<List<EventDto>> GetPublicEventsAsync();
        Task<List<EventDto>> GetByEventTypeIdAsync(int eventTypeId);
        Task<EventDetailsDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateEventDto dto);
        Task<bool> UpdateAsync(UpdateEventDto dto);
        Task<bool> DeleteAsync(int id);
    }
}