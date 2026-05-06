using Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Reservation
{
    public class UpdateReservationDto : CreateReservationDto
    {
        public int Id { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
