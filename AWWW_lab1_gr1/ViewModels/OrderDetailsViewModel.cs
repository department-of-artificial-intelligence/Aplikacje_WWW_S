using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.ViewModels;

public class OrderDetailsViewModel
{
    public Order Order { get; set; } = null!;
    public decimal TotalAmount { get; set; }
}
