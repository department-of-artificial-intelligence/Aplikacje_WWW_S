namespace Kolokwium.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
