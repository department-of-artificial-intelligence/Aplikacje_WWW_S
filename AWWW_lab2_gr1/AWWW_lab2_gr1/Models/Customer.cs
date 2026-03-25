namespace AWWW_lab2_gr1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CustomerProfile CustomerProfile { get; set; } //Referencja do CustomerProfile (1:1)
        public List<Address> Addresses { get; set; } //Kolekcja 1:N
        public List<Order> Orders { get; set; } //Kolekcja 1:N
        public List<Review> Reviews { get; set; } //Kolekcja 1:N
    }
}
