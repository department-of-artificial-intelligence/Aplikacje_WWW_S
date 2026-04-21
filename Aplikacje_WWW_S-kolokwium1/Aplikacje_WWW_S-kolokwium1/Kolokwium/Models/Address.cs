namespace Kolokwium.Models;

public class Address
{
    public int Id { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? ZipCode { get; set; }

    public int BuildingNumber { get; set; }

    public int? ApartmentNumber { get; set; }

    public List<Order>? Orders { get; set; }

    public List<Meal>? Meals { get; set; }

}
