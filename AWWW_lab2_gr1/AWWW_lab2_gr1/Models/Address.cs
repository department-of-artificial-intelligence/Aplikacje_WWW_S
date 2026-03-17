namespace AWWW_lab2_gr1.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public Customer Customer { get; set; }
    }
}
