namespace AWWW_lab2_gr1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public CustomerProfile? CustomerProfile { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}