using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum ReservationStatus
    {
        Pending,
        Approved,
        Rejected,
        Cancelled
    }


    public class Reservation
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }= null!;

        public int EventId { get; set; }
        public virtual Event Event { get; set; }= null!;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ReservationStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; } =string.Empty;
    }
}