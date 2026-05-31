namespace Web.ViewModels.Event
{
    public class EventReservationItemViewModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = null!;
        public string Notes { get; set; } = null!;
    }
}
