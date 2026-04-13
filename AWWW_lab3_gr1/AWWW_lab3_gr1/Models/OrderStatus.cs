namespace AWWW_lab3_gr1.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<OrderStatusHistory> StatusHistories { get; set; } = new List<OrderStatusHistory>();
    }
}
