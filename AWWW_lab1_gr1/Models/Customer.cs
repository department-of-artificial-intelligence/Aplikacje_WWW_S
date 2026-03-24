namespace AWWW_lab1_gr1.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public CustomerProfile? Profile { get; set; }
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
