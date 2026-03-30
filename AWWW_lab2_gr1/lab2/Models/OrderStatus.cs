using System;

public class OrderStatus
{
	
		public int Id { get; set; }

		public Status Status { get; set; }


		 // zamówienia, które aktualnie mają ten status
		public ICollection<Order> Orders { get; set; } = new List<Order>();

		// historia zmian z tym statusem
		public ICollection<OrderStatusHistory> StatusHistories { get; set; } = new List<OrderStatusHistory>();
    

	
	
}
