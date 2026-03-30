namespace AWWW_lab2_gr1.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public required string Name { get; set; } 

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<OrderStatusHistory> StatusHistories { get; set; } = new List<OrderStatusHistory>();
    }
}