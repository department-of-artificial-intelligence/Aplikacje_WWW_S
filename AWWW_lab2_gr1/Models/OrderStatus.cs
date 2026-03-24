namespace AWWW_lab2_gr1.Models;

public class OrderStatus
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<OrderStatusHistory> OrderStatusHistory { get; set; } = new List<OrderStatusHistory>();
}
