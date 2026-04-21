using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Type { get; set; }
		public string Category { get; set; }
		[Precision(18, 4)]
		public decimal TotalAmount { get; set; }
		public List<Order> Orders { get; set; }
	}
}
