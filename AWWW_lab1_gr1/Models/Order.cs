namespace AWWW_lab1_gr1.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
