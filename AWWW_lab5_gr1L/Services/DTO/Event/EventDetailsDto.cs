using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Event
{
    public class EventDetailsDto : EventDto
    {
        public string Description { get; set; } = null!;
        public int ParticipantsLimit { get; set; }
        public List<ReservationDto> Reservations { get; set; } = new();
    }
}
