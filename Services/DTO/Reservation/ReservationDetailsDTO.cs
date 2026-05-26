using Model;
using Services.DTO.Event;
using Services.DTO.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Reservation
{
    public class ReservationDetailsDTO
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public int EventId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ReservationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; }

        public EventDTO Event { get; set; }
        public RoomDTO Room { get; set; }
    }
}
