using System;
using Model.Entities;

namespace Services.DTO.Reservation
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; }
    }
}