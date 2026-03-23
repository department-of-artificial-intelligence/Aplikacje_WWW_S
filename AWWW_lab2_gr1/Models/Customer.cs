namespace AWWW_lab2_gr1.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public CustomerProfile Profile { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Review> Reviews { get; set; }
}