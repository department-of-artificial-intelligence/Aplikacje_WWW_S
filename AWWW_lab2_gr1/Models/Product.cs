using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        
        [Precision(18, 4)]
        public decimal Price { get; set; }
        
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}