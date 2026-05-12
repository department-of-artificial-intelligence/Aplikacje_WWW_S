namespace Services.DTO.Reservation
{
    public class CreateReservationDto
    {
        public int RoomId { get; set; }
        public int EventId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string? Notes { get; set; }
    }
}
