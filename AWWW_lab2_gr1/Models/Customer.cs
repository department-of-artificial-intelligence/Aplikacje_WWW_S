namespace AWWW_lab2_gr1.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual CustomerProfile? CustomerProfile { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
