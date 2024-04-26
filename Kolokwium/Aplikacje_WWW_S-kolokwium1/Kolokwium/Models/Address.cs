namespace Kolokwium.Models;

public class Address
{
    public int Id{get;set;}
    public string Country{get;set;}= null!;
    public string City{get;set;}= null!;
    public string Street{get;set;}= null!;
    public string ZipCode{get;set;}= null!;
    public int BuildingNumber{get;set;}
    public int? ApartamentNumber{get;set;}
    public ICollection<Order>? Orders{get;set;}
}
