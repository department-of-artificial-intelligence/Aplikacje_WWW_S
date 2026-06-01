using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Reservation
{
    public class ReservationDetialsDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; } = null!;


        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;

        public int EventId { get; set; }
        public string EventTitle { get; set; } = null!;
    }
}
