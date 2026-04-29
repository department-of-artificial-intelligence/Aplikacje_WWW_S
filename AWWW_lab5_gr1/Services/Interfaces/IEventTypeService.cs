using Services.DTO.EventType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEventTypeService
    {
        Task<IList<EventTypeDto>> GetAllAsync();
        Task<EventTypeDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateEventTypeDto dto);
        Task<bool> UpdateAsync(UpdateEventTypeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
