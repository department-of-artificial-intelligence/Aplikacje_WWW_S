using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum ReservationStatus
    {
        Pending = 0,
        Approved,
        Rejected,
        Cancelled
    }

    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set;  }
        public virtual Room Room { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public DateTime StartTime { get; set;  }

        public DateTime EndTime { get; set; }

        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Notes { get; set; }

    }
}
