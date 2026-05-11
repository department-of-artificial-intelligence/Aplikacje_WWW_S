using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Event
{
    public class UpdateEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int EventTypeId { get; set; }
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
    }
}