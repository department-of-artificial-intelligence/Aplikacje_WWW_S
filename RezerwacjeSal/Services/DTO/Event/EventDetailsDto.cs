using Services.DTO.Event;
using Services.DTO.Reservation;
using System.Collections.Generic;

namespace Services.DTO.Event
{
    public class EventDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; } = null!;
        public List<ReservationDto> Reservations { get; set; } = new();
    }
}
