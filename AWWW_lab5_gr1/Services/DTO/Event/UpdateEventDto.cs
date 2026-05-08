using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Event
{
    public class UpdateEventDto : CreateEventDto
    {
        public int Id { get; set; }
    }
}
