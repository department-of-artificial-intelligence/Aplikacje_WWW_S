using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.ReservationStatus;

namespace Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; }


        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public int EventId { get; set; }
        public Event? Event { get; set; }
    }
}
