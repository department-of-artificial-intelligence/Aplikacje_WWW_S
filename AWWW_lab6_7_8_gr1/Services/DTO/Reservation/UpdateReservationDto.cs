using System;
using Model.Entities; // Dla ReservationStatus

namespace Services.DTO.Reservation
{
    public class UpdateReservationDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int EventId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; }
        public string? Notes { get; set; }
    }
}