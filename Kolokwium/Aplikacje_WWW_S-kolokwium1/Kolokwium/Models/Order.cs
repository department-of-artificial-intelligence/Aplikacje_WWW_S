namespace Kolokwium.Models;

public class Order
{
    public int Id{get;set;}
    public DateTime OrderDate{get;set;}
    public DateTime DeliveryDate{get;set;} //not today, that's for sure
    public decimal TotalPrice{get;}
    public Address DeliveryAddress{get;set;}= null!;
    public ICollection<Meal>? Meals{get;set;}
}
