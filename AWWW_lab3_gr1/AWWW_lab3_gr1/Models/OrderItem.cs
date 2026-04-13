namespace AWWW_lab3_gr1.Models;
using Microsoft.EntityFrameworkCore;

public class OrderItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    [Precision(18,4)]
    public decimal UnitPrice { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
