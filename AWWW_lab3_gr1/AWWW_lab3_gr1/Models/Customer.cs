namespace AWWW_lab3_gr1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public CustomerProfile? CustomerProfile { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
