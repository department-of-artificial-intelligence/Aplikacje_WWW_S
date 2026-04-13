namespace Kolokwium.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string CustomerName { get; set; }
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }

    }
}
