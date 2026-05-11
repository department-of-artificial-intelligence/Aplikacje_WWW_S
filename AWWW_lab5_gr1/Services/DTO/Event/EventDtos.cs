using Model.DataModels;

namespace Services.DTO.Event
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string EventTypeName { get; set; } = null!;
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ReservationDto
    {
        public int Id { get; set; }
        public string RoomName { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; }
    }

    public class EventDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string EventTypeName { get; set; } = null!;
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ReservationDto> Reservations { get; set; } = new();
    }

    public class CreateEventDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int EventTypeId { get; set; }
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
    }

    public class UpdateEventDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int EventTypeId { get; set; }
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
    }
}