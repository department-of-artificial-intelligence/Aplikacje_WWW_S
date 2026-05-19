using Services.DTO.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IEventService {
        Task<List<EventDTO>> GetAllAsync();
        Task<List<EventDTO>> GetPublicEventsAsync();
        Task<List<EventDTO>> GetByEventTypeIdAsync(int eventTypeId);
        Task<EventDetailsDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateEventDTO dto);
        Task<bool> UpdateAsync(UpdateEventDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
