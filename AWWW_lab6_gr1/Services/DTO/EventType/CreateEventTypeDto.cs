using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.EventType
{
    public class CreateEventTypeDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
