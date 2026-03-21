namespace AWWW_lab2_gr1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } //referencja do 1 Customer

        public List<OrderItem> OrderItems { get; set; } //Kolekcja 1:N (jedno zamowienie, kilka przedmiotow)
    }
}
