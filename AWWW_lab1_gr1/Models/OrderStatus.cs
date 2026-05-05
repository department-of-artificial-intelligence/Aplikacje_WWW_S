namespace AWWW_lab1_gr1.Models;

public class OrderStatus
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<OrderStatusHistory> StatusHistoryEntries { get; set; } = new List<OrderStatusHistory>();
}
