using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Reservation
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public int EventId { get; set; }
        public string EventTitle { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = null!;
        public string Notes { get; set; } = null!;
    }
}
