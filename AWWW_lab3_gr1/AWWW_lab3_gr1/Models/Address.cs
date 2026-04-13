namespace AWWW_lab3_gr1.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
