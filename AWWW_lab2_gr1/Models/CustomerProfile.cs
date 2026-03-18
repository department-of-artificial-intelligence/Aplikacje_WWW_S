namespace AWWW_lab2_gr1.Models;

public class CustomerProfile
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Phone { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
