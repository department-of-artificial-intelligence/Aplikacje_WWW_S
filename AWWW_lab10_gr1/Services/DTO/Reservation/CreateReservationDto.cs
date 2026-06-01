using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Reservation
{
    public class CreateReservationDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus? Status { get; set; }
        public string Notes { get; set; } = null!;

        public int RoomId { get; set; }
        public int EventId { get; set; }
    }
}
