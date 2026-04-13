namespace Kolokwium.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Rating { get; set; }

        public List<Room> Rooms { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
