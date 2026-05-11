using System;
using System.Collections.Generic;
using Services.DTO.Reservation;

namespace Services.DTO.Event
{
    public class EventDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
        public string EventTypeName { get; set; } = string.Empty;
        
        public List<ReservationDto> Reservations { get; set; } = new();
    }
}