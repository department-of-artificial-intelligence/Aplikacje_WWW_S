using Model.DataModels;

namespace Services.DTO.Reservation
{
    public class ReservationListDto
    {
        public int Id { get; set; }
        public string RoomName { get; set; } = null!;
        public string EventTitle { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; }
    }

    public class CreateReservationDto
    {
        public int RoomId { get; set; }
        public int EventId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Notes { get; set; }
    }

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