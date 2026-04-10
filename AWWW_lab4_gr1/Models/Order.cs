namespace AWWW_lab4_gr1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } //foreign key
        public int OrderStatusId { get; set; } //foreign key
        public DateTime CreatedAt { get; set; }
    }
}
