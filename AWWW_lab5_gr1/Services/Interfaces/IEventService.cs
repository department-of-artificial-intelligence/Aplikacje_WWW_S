using Services.DTO.Event;
using Services.DTO.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEventService
    {
        Task<IList<EventDto>> GetAllAsync();
        Task<IList<EventDto>> GetPublicEventsAsync();
        Task<IList<EventDto>> GetByEventTypeIdAsync(int eventTypeId);
        Task<EventDetailsDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateEventDto dto);
        Task<bool> UpdateAsync(UpdateEventDto dto);
        Task<bool> DeleteAsync(int id);
    }
}