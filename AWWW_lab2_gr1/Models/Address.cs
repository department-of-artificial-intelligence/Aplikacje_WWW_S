using System.Reflection;

public class Addresses
{
    public int Id {get; set;}
    public int CustomerId {get; set;}
    public required string City {get; set;}
    public required string Street {get; set;}
    public required string PostalCode {get; set;}

    public Customer? Customer{get; set;}

}