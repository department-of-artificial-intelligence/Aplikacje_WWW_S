using Services.DTO.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Event
{
    public class EventDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string EventTypeName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<ReservationDto> Reservations { get; set; } = new();
    }
}