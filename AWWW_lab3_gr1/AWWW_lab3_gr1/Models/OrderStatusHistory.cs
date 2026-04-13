namespace AWWW_lab3_gr1.Models
{
    public class OrderStatusHistory
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; } = null!;
        public DateTime ChangedAt { get; set; }
    }
}
