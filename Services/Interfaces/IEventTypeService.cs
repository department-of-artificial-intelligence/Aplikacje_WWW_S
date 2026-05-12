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
        Task<List<EventTypeDTO>> GetAllAsync();
        Task<EventTypeDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateEventTypeDTO dto);
        Task<bool> UpdateAsync(UpdateEventTypeDTO dto);

        Task<bool> DeleteAsync(DeleteEventTypeDTO dto);
    }
}
