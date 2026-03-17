namespace AWWW_lab2_gr2.Models;

public class Customer_Profile
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Phone { get; set; } = "";
    public DateTime DateOfBirth { get; set; }

    public Customer Customer { get; set; }
}

