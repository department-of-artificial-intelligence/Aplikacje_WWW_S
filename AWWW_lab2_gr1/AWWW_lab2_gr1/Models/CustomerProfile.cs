namespace AWWW_lab2_gr1.Models
{
    public class CustomerProfile
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Customer Customer { get; set; } //referencja do 1 Customer
    }
}
