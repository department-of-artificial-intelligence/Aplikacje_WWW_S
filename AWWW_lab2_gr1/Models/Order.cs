namespace AWWW_lab2_gr1.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
