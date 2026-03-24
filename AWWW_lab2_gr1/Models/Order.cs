namespace AWWW_lab2_gr1.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int OrderStatusId { get; set; } // klucz obcy do aktualnego statusu
    public DateTime CreatedAt { get; set; }

    public Customer Customer { get; set; }
    public OrderStatus OrderStatus { get; set; } // nawigacja do aktualnego statusu
    public ICollection<OrderItem> OrderItems { get; set; }
    public ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } // historia zmian statusów
}