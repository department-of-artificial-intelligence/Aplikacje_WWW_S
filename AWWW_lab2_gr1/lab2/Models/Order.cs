using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}