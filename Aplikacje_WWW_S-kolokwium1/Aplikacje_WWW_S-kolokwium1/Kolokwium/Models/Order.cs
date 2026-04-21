namespace Kolokwium.Models;

public class Order
{

    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public decimal TotalPrice { get; }

    public Address? DeliveryAddress { get; set; }
}
