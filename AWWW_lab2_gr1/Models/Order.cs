namespace AWWW_lab2_gr1.Models
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public int CustomerId {  get; set; }
		public int OrderStatusId {  get; set; }
		public OrderStatus OrderStatus { get; set; }

		public List<OrderItem> OrderItems { get; set; }
		public List<OrderStatusHistory> OrderStatusHistories { get; set; }
	}
}
