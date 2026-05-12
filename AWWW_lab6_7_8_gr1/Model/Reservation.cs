using System;

namespace Model.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int EventId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; } = string.Empty;

        public virtual Room Room { get; set; } = null!;
        public virtual Event Event { get; set; } = null!;
    }
}