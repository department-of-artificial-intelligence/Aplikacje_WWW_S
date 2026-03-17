namespace AWWW_lab2_gr1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CustomerProfile CustomerProfile { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
