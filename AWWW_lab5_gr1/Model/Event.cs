using System;
using System.Collections.Generic;

namespace Model.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}