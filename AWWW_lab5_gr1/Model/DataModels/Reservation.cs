using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModels
{
    public enum ReservationStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Cancelled = 3
    }

    public class Reservation
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ReservationStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; }
    }
}
