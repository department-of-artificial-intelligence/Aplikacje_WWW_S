namespace AWWW_lab2_gr1.Models
{
    public class OrderStatusHistory
    {
        public int Id { get; set; }
        public DateTime DateChanged { get; set; } = DateTime.Now;

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int? OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; } = null!;
    }
}