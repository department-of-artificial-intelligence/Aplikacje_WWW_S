namespace Kolokwium.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
