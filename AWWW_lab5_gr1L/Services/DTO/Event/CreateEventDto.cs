using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Event
{
    public class CreateEventDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
        public int EventTypeId { get; set; }
    }
}
