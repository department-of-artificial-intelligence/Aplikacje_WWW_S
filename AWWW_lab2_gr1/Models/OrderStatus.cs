namespace AWWW_lab2_gr1.Models
{
	public class OrderStatus
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<Order> Orders { get; set; }
		public List<OrderStatusHistory> OrderStatusHistories { get; set; }
	}
}
