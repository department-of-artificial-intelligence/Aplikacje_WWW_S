namespace Web.ViewModels.Event
{
    public class DetailsEventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string EventTypeName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsPublic { get; set; }

        public List<EventReservationItemViewModel> Reservations { get; set; } = new();
    }
}
