using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.EventType
{
    public class UpdateEventTypeDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
