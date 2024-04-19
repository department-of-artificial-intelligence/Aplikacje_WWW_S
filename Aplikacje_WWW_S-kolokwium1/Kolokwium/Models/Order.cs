namespace Kolokwium.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string ShippingAddress { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public DateTime DueDate { get; set; }

        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
