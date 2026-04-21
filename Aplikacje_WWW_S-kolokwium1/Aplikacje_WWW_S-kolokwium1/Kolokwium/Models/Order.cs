using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
		public string ShippingAddress { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
		[Precision(18, 4)]
		public decimal TotalAmount { get;}
		public DateTime DueDate { get; set; }
		public int ClientId { get; set; }
		public Client Client { get; set; }
		public List<Product> Products { get; set; }
	}
}
