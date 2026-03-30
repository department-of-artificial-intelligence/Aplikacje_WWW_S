namespace AWWW_lab2_gr1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public int? OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; } = null!;

        public ICollection<OrderStatusHistory> StatusHistories { get; set; } = new List<OrderStatusHistory>();
    }
}