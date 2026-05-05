using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.DataModels
{
    public class Reservation
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public int EventId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [MaxLength(1000)]
        public string? Notes { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room? Room { get; set; }

        [ForeignKey("EventId")]
        public virtual Event? Event { get; set; }
    }
}
