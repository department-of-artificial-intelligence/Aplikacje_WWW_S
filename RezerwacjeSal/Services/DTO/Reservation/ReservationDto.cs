namespace Services.DTO.Reservation
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public int EventId { get; set; }
        public string EventTitle { get; set; } = null!;
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public Model.DataModels.ReservationStatus Status { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string? Notes { get; set; }
    }
}
