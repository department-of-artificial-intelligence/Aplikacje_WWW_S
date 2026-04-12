namespace AWWW_lab2_gr1.Models;


public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public Customer_Profile Profile { get; set; } = new();

    public List<Adress> Adresess { get; set; } = new();

    public Order Orders { get; set; } = new();
}



