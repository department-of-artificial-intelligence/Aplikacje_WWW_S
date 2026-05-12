using System;

namespace Services.DTO.Event
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
        public string EventTypeName { get; set; } = string.Empty;
    }
}