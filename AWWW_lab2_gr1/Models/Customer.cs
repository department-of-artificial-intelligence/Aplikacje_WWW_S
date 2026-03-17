public class Customer
{
    public int Id {get; set;}
    public required string Name {get; set;}

    public CustomerProfile?Profile{get; set;}
    public List<Adress> Addresses {get; set;} = new List<Adress>();
    public List<Order> Orders {get; set;} = new List<Order>();
    public List<Review> Reviews {get; set;} = new List<Review>();

}