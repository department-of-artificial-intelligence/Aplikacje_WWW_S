public class Customer_Profile
{
    public int Id {get; set;}
    public int CustomerId {get; set;}
    public required string Phone {get; set;}
    public DateTime DateOfBirth {get; set;}

    public Customer? Customer {get; set;}
}