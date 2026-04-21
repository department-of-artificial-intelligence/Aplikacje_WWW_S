namespace Kolokwium.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalPrice { get; }
        public int AddressId { get; set; }
        public Address DelieveryAddress { get; set; }
        public List<Meal> Meals { get; set; } = new List<Meal>();
    }
}
