namespace Kolokwium.Model.DataModels
{
    public class Product
    {
        public int Id {get; set;}
        public string Type {get; set;} = string.Empty;
        public string Category {get; set; } = string.Empty;
        public decimal Price {get; set; }

        public virtual ICollection<Order> Orders {get; set; } = new List<Order>();
    }
}