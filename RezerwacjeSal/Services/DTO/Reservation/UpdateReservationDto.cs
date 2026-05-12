namespace Services.DTO.Reservation
{
    public class UpdateReservationDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int EventId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public Model.DataModels.ReservationStatus Status { get; set; }
        public string? Notes { get; set; }
    }
}
