namespace AWWW_lab2_gr1.Models;

public class OrderStatus
{
    public int Id { get; set; }
    public string Name { get; set; } // np. "New", "Paid", "Shipped", "Completed"

    public ICollection<Order> Orders { get; set; } // wiele zamówień może mieć ten status jako aktualny
    public ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } // wiele wpisów historii dla tego statusu
}