namespace Kolokwium.Model.DataModels
{
    public class Order
    {
        public int Id {get; set;}
        public DateTime CreationDate {get; set;}
        public string ShippingAddress {get; set; } = string.Empty;
        public string? Description {get; set; }
        public string Status {get; set; } = string.Empty;

        public decimal TotalAmount {get; }
        public DateTime DueDate {get; set;}

        public int? ClientId {get; set;}
        public virtual Client? Client {get; set;}

        public virtual ICollection<Product> Products {get; set;} = new List<Product>();
    }
}