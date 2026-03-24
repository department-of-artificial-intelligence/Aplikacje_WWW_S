using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Models;

public class OrderStatus
{
    public int Id {get; set;}
    public string Status { get; set;}

    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<OrderStatusHistory> StatusHistory { get; set; } = new List<OrderStatusHistory>();

}
