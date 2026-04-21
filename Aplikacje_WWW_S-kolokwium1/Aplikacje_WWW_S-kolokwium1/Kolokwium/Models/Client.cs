namespace Kolokwium.Models
{
	public class Client
	{
		public int Id { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email {  get; set; }
		public string Phone { get; set; }
		public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
