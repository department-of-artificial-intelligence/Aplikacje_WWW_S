namespace Kolokwium.Models;

public class Meal
{
    public int Id{get;set;}
    public string Type{get;set;}= null!;
    public bool IsVegetarian{get;set;}
    public string Description{get;set;}= null!;
    public decimal Price{get;set;}




    public ICollection<Order>? Orders{get;set;}

}
