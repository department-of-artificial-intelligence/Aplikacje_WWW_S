using Model;
using Services.DTO.Room;
using Services.DTO.Event;
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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; } = null!;
    }
}
