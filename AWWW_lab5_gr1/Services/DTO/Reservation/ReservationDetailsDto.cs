using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Reservation
{
    public class ReservationDetailsDto : ReservationDto
    {
        public string Notes { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int RoomId { get; set; }
        public int EventId { get; set; }
    }
}
