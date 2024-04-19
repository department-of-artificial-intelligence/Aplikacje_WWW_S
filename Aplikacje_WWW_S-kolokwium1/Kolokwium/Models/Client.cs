namespace Kolokwium.Models
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
