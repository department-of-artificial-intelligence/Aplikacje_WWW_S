namespace AWWW_lab2_gr1.Models;

public class Address
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;

    public Customer Customer { get; set; } = null!;
}
