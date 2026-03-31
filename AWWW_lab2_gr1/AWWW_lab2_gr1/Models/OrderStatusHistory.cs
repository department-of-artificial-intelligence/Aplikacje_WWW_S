namespace AWWW_lab2_gr1.Models
{
    public class OrderStatusHistory
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime ChangedAt { get; set; } 

        public Order Order { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
