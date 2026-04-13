namespace AWWW_lab3_gr1.Models
{
    public class CustomerProfile
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public string Phone { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Customer Customer { get; set; } = null!;

    }
}
