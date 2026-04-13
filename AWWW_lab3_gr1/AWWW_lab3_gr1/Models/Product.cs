using Microsoft.EntityFrameworkCore;

namespace AWWW_lab3_gr1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Precision(18,4)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    }
}
