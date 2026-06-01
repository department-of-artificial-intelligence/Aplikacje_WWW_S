using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTO.Reservation;

namespace Services.DTO.Event
{
    public class EventDetailsDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }

        public DateTime CreatedAt { get; set; }

        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; } = null!;

        public List<ReservationDto> Reservations { get; set; } = null!;
    }
}
