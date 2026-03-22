namespace AWWW_lab2_gr1.Models
{
    public class Address
    {
        public int? Id { get; set; } //nulle bo nie ma klientow z ktorymi powiazana jest baza i sie psulo
        public int? CustomerId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; } // 

        public Customer? Customer { get; set; } //referencja do 1 Customer
    }
}
